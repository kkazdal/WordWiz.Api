using MediatR;
using WordWiz.Application.Features.Categories.Queries.GetAllCategories.ViewModels;

namespace WordWiz.Application.Features.Categories.Queries.GetAllCategories;

public record GetAllCategoriesQuery : IRequest<IEnumerable<CategoryViewModel>>; 