using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Net.Http.Headers;
using Microsoft.Identity.Web;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AppServices.MapperProfiles;
using DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(AppServices.Models.Category).Assembly);
});
builder.Services.AddAutoMapper(typeof(ContactProfile));

builder.Services.AddDbContext<ContactsContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ContactsDataBase;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddScoped<DAL.Repositories.ContactRepository>();
builder.Services.AddScoped<DAL.Repositories.CategoryRepository>();
builder.Services.AddScoped<DAL.Repositories.SubcategoryRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ContactsContext>();
    DBSeeder.Seed(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseCors(policy =>
    policy.WithOrigins(builder.Configuration.GetSection("FrontendUrl").Value)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithHeaders(HeaderNames.ContentType));
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
