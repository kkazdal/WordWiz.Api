using MediatR;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Words.Commands.CreateWord;

public class CreateWordCommandHandler : IRequestHandler<CreateWordCommand, long>
{
    private readonly IRepository<Word> _wordRepository;

    public CreateWordCommandHandler(IRepository<Word> wordRepository)
    {
        _wordRepository = wordRepository;
    }

    public async Task<long> Handle(CreateWordCommand request, CancellationToken cancellationToken)
    {
        var word = new Word
        {
            WordText = request.Text,
            PartOfSpeech = request.PartOfSpeech,
            Synonyms = request.Synonyms,
            Definition = request.Definition
        };

        var result = await _wordRepository.AddAsync(word);
        return result.Id;
    }
} 