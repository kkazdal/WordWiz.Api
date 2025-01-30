namespace WordWiz.Application.Features.Questions.Queries.GetQuestionById.ViewModels;

public class QuestionViewModel
{
    public long Id { get; set; }
    public string QuestionText { get; set; } = null!;
    public string CorrectAnswer { get; set; } = null!;
    public long CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public List<string> Choices { get; set; } = new();
} 