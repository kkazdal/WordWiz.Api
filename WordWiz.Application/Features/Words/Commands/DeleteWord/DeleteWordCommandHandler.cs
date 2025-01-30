using MediatR;
using WordWiz.Application.Common.Exceptions;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Words.Commands.DeleteWord;

public class DeleteWordCommandHandler : IRequestHandler<DeleteWordCommand, Unit>
{
    private readonly IRepository<Word> _wordRepository;

    public DeleteWordCommandHandler(IRepository<Word> wordRepository)
    {
        _wordRepository = wordRepository;
    }

    public async Task<Unit> Handle(DeleteWordCommand request, CancellationToken cancellationToken)
    {
        var word = await _wordRepository.GetByIdAsync(request.Id);
        if (word == null)
            throw new CustomException($"Word with ID {request.Id} not found.");

        await _wordRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
} 