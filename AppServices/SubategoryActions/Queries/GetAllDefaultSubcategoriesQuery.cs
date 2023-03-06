using MediatR;
using AppServices.Models;

namespace AppServices.SubcategoryActions.Queries;

public class GetAllDefaultSubcategoriesQuery : IRequest<List<Subcategory>>
{
}