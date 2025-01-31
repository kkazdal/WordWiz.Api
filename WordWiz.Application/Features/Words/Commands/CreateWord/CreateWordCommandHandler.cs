using MediatR;
using WordWiz.Application.Common.Exceptions;
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
        var words = await _wordRepository.GetAllAsync();
        if (words.Any(w => w.WordText.Equals(request.Text, StringComparison.OrdinalIgnoreCase)))
        {
            throw new CustomException($"Word '{request.Text}' already exists in the database.");
        }

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