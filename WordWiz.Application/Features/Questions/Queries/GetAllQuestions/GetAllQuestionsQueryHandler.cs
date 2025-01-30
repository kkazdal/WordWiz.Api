using AutoMapper;
using MediatR;
using WordWiz.Application.Common.ViewModels;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Questions.Queries.GetAllQuestions;

public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQuery, IEnumerable<QuestionViewModel>>
{
    private readonly IRepository<Question> _questionRepository;
    private readonly IMapper _mapper;

    public GetAllQuestionsQueryHandler(IRepository<Question> questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<QuestionViewModel>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = await _questionRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<QuestionViewModel>>(questions);
    }
} 