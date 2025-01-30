using MediatR;

namespace WordWiz.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<long>
{
    public string Name { get; set; } = null!;
} 