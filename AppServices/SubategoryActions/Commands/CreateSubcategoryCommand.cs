using MediatR;
using AppServices.Models;

namespace AppServices.SubcategoryActions.Commands;

public class CreateSubcategoryCommand : IRequest
{
    public string? SubcategoryName { get; set; }
}