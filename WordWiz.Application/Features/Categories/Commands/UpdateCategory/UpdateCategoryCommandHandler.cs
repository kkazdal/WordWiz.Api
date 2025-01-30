using MediatR;
using WordWiz.Application.Common.Exceptions;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly IRepository<Category> _categoryRepository;

    public UpdateCategoryCommandHandler(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category == null)
            throw new CustomException($"Category with ID {request.Id} not found.");

        category.Name = request.Name;

        await _categoryRepository.UpdateAsync(category);
        return Unit.Value;
    }
} 