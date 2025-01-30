using MediatR;

namespace WordWiz.Application.Features.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(long Id) : IRequest<Unit>; 