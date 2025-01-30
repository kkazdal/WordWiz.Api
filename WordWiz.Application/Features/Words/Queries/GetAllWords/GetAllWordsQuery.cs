using MediatR;
using WordWiz.Application.Features.Words.Queries.GetWordById.ViewModels;

namespace WordWiz.Application.Features.Words.Queries.GetAllWords;

public record GetAllWordsQuery : IRequest<IEnumerable<WordViewModel>>; 