using MediatR;
using DAL.Repositories;
using AppServices.SubcategoryActions.Commands;

namespace AppServices.SubcategoryActions.Handlers;

public class CreateSubcategoryHandler : IRequestHandler<CreateSubcategoryCommand, int>
{
    private readonly SubcategoryRepository _subcategoryRepository;

    public CreateSubcategoryHandler(SubcategoryRepository subcategoryRepository)
    {
        _subcategoryRepository = subcategoryRepository;
    }

    public async Task<int> Handle(CreateSubcategoryCommand request, CancellationToken cancellationToken)
    {
        int newSubcategoryId = await _subcategoryRepository.CreateSubcategory(request.SubcategoryName!, request.CategoryId);
        return newSubcategoryId;
    }
}