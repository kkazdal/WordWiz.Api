using AutoMapper;
using MediatR;
using WordWiz.Application.Features.Words.Queries.GetWordById.ViewModels;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Words.Queries.GetAllWords;

public class GetAllWordsQueryHandler : IRequestHandler<GetAllWordsQuery, IEnumerable<WordViewModel>>
{
    private readonly IRepository<Word> _wordRepository;
    private readonly IMapper _mapper;

    public GetAllWordsQueryHandler(IRepository<Word> wordRepository, IMapper mapper)
    {
        _wordRepository = wordRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WordViewModel>> Handle(GetAllWordsQuery request, CancellationToken cancellationToken)
    {
        var words = await _wordRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<WordViewModel>>(words);
    }
} 