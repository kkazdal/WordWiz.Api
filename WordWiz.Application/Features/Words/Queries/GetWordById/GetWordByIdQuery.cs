using MediatR;
using WordWiz.Application.Features.Words.Queries.GetWordById.ViewModels;

namespace WordWiz.Application.Features.Words.Queries.GetWordById;

public record GetWordByIdQuery(long Id) : IRequest<WordViewModel>; 