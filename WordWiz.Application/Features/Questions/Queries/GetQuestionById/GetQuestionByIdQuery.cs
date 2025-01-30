using MediatR;
using WordWiz.Application.Common.ViewModels;

namespace WordWiz.Application.Features.Questions.Queries.GetQuestionById;

public record GetQuestionByIdQuery(long Id) : IRequest<QuestionViewModel>; 