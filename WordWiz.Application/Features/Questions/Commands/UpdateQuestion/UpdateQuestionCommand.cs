using MediatR;

namespace WordWiz.Application.Features.Questions.Commands.UpdateQuestion;

public class UpdateQuestionCommand : IRequest<Unit>
{
    public long Id { get; set; }
    public string QuestionText { get; set; } = null!;
    public string CorrectAnswer { get; set; } = null!;
    public long CategoryId { get; set; }
    public List<string> Choices { get; set; } = new();
} 