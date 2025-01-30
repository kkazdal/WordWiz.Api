using AutoMapper;
using MediatR;
using WordWiz.Application.Common.Exceptions;
using WordWiz.Application.Common.ViewModels;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Questions.Queries.GetQuestionById;

public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, QuestionViewModel>
{
    private readonly IRepository<Question> _questionRepository;
    private readonly IMapper _mapper;

    public GetQuestionByIdQueryHandler(IRepository<Question> questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<QuestionViewModel> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.GetByIdAsync(request.Id);
        
        if (question == null)
            throw new CustomException($"Question with ID {request.Id} not found.");

        return _mapper.Map<QuestionViewModel>(question);
    }
} 