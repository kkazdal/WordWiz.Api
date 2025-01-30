using MediatR;

namespace WordWiz.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
} 