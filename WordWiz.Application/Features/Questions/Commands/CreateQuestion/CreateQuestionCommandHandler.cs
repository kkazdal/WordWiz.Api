using MediatR;
using WordWiz.Application.Common.Exceptions;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, long>
{
    private readonly IRepository<Question> _questionRepository;
    private readonly IRepository<Category> _categoryRepository;

    public CreateQuestionCommandHandler(IRepository<Question> questionRepository, IRepository<Category> categoryRepository)
    {
        _questionRepository = questionRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<long> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
        if (category == null)
            throw new CustomException($"Category with ID {request.CategoryId} not found.");

        var question = new Question
        {
            QuestionText = request.QuestionText,
            CorrectAnswer = request.CorrectAnswer,
            CategoryId = request.CategoryId
        };
        
        question.SetChoices(request.Choices);

        var result = await _questionRepository.AddAsync(question);
        return result.Id;
    }
} 