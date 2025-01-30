using MediatR;
using WordWiz.Application.Features.Categories.Queries.GetCategoryById.ViewModels;

namespace WordWiz.Application.Features.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(long Id) : IRequest<CategoryViewModel>; 