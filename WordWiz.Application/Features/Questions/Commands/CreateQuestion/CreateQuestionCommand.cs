using MediatR;

namespace WordWiz.Application.Features.Questions.Commands.CreateQuestion;

public class CreateQuestionCommand : IRequest<long>
{
    public string QuestionText { get; set; } = null!;
    public string CorrectAnswer { get; set; } = null!;
    public long CategoryId { get; set; }
    public List<string> Choices { get; set; } = new();
} 