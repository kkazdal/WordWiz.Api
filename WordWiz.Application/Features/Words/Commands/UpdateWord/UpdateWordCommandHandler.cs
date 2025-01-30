using MediatR;
using WordWiz.Application.Common.Exceptions;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Words.Commands.UpdateWord;

public class UpdateWordCommandHandler : IRequestHandler<UpdateWordCommand, Unit>
{
    private readonly IRepository<Word> _wordRepository;

    public UpdateWordCommandHandler(IRepository<Word> wordRepository)
    {
        _wordRepository = wordRepository;
    }

    public async Task<Unit> Handle(UpdateWordCommand request, CancellationToken cancellationToken)
    {
        var word = await _wordRepository.GetByIdAsync(request.Id);
        if (word == null)
            throw new CustomException($"Word with ID {request.Id} not found.");

        word.WordText = request.Text;
        word.PartOfSpeech = request.PartOfSpeech;
        word.Synonyms = request.Synonyms;
        word.Definition = request.Definition;

        await _wordRepository.UpdateAsync(word);
        return Unit.Value;
    }
} 