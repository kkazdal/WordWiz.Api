using WordWiz.Domain.Entities.Common;

namespace WordWiz.Domain.Entities;

public class Word : BaseEntity
{
    public string WordText { get; set; } = null!;
    public string PartOfSpeech { get; set; } = null!;
    public string Synonyms { get; set; } = null!;
    public string Definition { get; set; } = null!;
} 