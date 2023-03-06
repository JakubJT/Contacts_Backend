using MediatR;
using AutoMapper;
using DAL.Repositories;
using AppServices.Models;
using AppServices.SubcategoryActions.Queries;

namespace AppServices.SubcategoryActions.Handlers;

public class GetAllDefaultSubcategoriesHandler : IRequestHandler<GetAllDefaultSubcategoriesQuery, List<Subcategory>>
{
    private readonly SubcategoryRepository _subcategoryRepository;
    private readonly IMapper _mapper;

    public GetAllDefaultSubcategoriesHandler(SubcategoryRepository subcategoryRepository, IMapper mapper)
    {
        _subcategoryRepository = subcategoryRepository;
        _mapper = mapper;
    }

    public async Task<List<Subcategory>> Handle(GetAllDefaultSubcategoriesQuery request, CancellationToken cancellationToken)
    {
        var subcategories = await _subcategoryRepository.GetAllDefaultSubcategories();
        return _mapper.Map<List<AppServices.Models.Subcategory>>(subcategories);
    }
}