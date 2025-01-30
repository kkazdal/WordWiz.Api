using MediatR;

namespace WordWiz.Application.Features.Words.Commands.DeleteWord;

public record DeleteWordCommand(long Id) : IRequest<Unit>; 