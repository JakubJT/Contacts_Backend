using MediatR;
using AppServices.Models;

namespace AppServices.CategoryActions.Queries;

public class GetAllCategoriesQuery : IRequest<List<Category>>
{
}