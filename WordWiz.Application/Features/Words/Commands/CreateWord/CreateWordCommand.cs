using MediatR;

namespace WordWiz.Application.Features.Words.Commands.CreateWord;

public class CreateWordCommand : IRequest<long>
{
    public string Text { get; set; } = null!;
    public string PartOfSpeech { get; set; } = null!;
    public string Synonyms { get; set; } = null!;
    public string Definition { get; set; } = null!;
} 