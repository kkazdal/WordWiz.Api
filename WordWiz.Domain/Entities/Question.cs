using System.Text.Json;
using WordWiz.Domain.Entities.Common;

namespace WordWiz.Domain.Entities;

public class Question : BaseEntity
{
    public string QuestionText { get; set; } = null!;
    public string CorrectAnswer { get; set; } = null!;
    public long CategoryId { get; set; }
    public string Choices { get; set; } = null!; // Will store as JSON
    public Category Category { get; set; } = null!;

    // Helper methods for Choices
    public List<string> GetChoices()
    {
        return JsonSerializer.Deserialize<List<string>>(Choices) ?? new List<string>();
    }

    public void SetChoices(List<string> choices)
    {
        Choices = JsonSerializer.Serialize(choices);
    }
} 