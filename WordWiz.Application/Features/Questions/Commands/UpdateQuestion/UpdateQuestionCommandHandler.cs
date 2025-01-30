using MediatR;
using WordWiz.Application.Common.Exceptions;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Questions.Commands.UpdateQuestion;

public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, Unit>
{
    private readonly IRepository<Question> _questionRepository;
    private readonly IRepository<Category> _categoryRepository;

    public UpdateQuestionCommandHandler(IRepository<Question> questionRepository, IRepository<Category> categoryRepository)
    {
        _questionRepository = questionRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.GetByIdAsync(request.Id);
        if (question == null)
            throw new CustomException($"Question with ID {request.Id} not found.");

        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
        if (category == null)
            throw new CustomException($"Category with ID {request.CategoryId} not found.");

        question.QuestionText = request.QuestionText;
        question.CorrectAnswer = request.CorrectAnswer;
        question.CategoryId = request.CategoryId;
        question.SetChoices(request.Choices);

        await _questionRepository.UpdateAsync(question);
        return Unit.Value;
    }
} 