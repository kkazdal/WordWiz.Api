using MediatR;

namespace WordWiz.Application.Features.Questions.Commands.DeleteQuestion;

public record DeleteQuestionCommand(long Id) : IRequest<Unit>; 