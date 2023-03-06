using MediatR;
using AutoMapper;
using DAL.Repositories;
using AppServices.Models;
using AppServices.CategoryActions.Queries;

namespace AppServices.CategoryActions.Handlers;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
{
    private readonly CategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoriesHandler(CategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllCategories();
        return _mapper.Map<List<AppServices.Models.Category>>(categories);
    }
}