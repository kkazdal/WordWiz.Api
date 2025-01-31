namespace WordWiz.Application.Features.Words.Queries.GetWordById.ViewModels;

public class WordViewModel
{
    public long Id { get; set; }
    public string WordText { get; set; }
    public string PartOfSpeech { get; set; }
    public string Synonyms { get; set; }
    public string Definition { get; set; }
}