using MediatR;
using AppServices.Models;

namespace AppServices.SubcategoryActions.Commands;

public class CreateSubcategoryCommand : IRequest<int>
{
    public string? SubcategoryName { get; set; }
    public int CategoryId { get; set; }
}