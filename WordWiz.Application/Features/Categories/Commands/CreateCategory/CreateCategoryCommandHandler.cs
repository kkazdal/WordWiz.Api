using MediatR;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, long>
{
    private readonly IRepository<Category> _categoryRepository;

    public CreateCategoryCommandHandler(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<long> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name
        };

        var result = await _categoryRepository.AddAsync(category);
        return result.Id;
    }
} 