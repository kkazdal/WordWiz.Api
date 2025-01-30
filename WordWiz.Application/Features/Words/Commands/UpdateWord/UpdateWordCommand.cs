using MediatR;

namespace WordWiz.Application.Features.Words.Commands.UpdateWord;

public class UpdateWordCommand : IRequest<Unit>
{
    public long Id { get; set; }
    public string Text { get; set; } = null!;
    public string PartOfSpeech { get; set; } = null!;
    public string Synonyms { get; set; } = null!;
    public string Definition { get; set; } = null!;
} 