using System;
using MediatR;
using WordWiz.Application.Common.Exceptions;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Questions.Commands.DeleteQuestion;

public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, Unit>
{
    private readonly IRepository<Question> _questionRepository;


    public DeleteQuestionCommandHandler(IRepository<Question> questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        var category = await _questionRepository.GetByIdAsync(request.Id);
        
        if (category == null)
            throw new CustomException($"Category with ID {request.Id} not found.");

        await _questionRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
