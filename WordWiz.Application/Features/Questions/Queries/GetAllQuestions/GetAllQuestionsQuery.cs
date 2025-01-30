using MediatR;
using WordWiz.Application.Common.ViewModels;

namespace WordWiz.Application.Features.Questions.Queries.GetAllQuestions;

public record GetAllQuestionsQuery : IRequest<IEnumerable<QuestionViewModel>>; 