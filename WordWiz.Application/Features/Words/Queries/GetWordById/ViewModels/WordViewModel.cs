namespace WordWiz.Application.Features.Words.Queries.GetWordById.ViewModels;

public class WordViewModel
{
    public Guid Id { get; set; }
    public string Text { get; set; } = null!;
    public string? Description { get; set; }
    public string? Example { get; set; }
} 