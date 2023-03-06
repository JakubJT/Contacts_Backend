using MediatR;
using DAL.Repositories;
using AppServices.SubcategoryActions.Commands;

namespace AppServices.SubcategoryActions.Handlers;

public class CreateSubcategoryHandler : IRequestHandler<CreateSubcategoryCommand>
{
    private readonly SubcategoryRepository _subcategoryRepository;

    public CreateSubcategoryHandler(SubcategoryRepository subcategoryRepository)
    {
        _subcategoryRepository = subcategoryRepository;
    }

    public async Task Handle(CreateSubcategoryCommand request, CancellationToken cancellationToken)
    {
        await _subcategoryRepository.CreateSubcategory(request.SubcategoryName!);
    }
}