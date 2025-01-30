using AutoMapper;
using MediatR;
using WordWiz.Application.Common.Exceptions;
using WordWiz.Application.Features.Words.Queries.GetWordById.ViewModels;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Words.Queries.GetWordById;

public class GetWordByIdQueryHandler : IRequestHandler<GetWordByIdQuery, WordViewModel>
{
    private readonly IRepository<Word> _wordRepository;
    private readonly IMapper _mapper;

    public GetWordByIdQueryHandler(IRepository<Word> wordRepository, IMapper mapper)
    {
        _wordRepository = wordRepository;
        _mapper = mapper;
    }

    public async Task<WordViewModel> Handle(GetWordByIdQuery request, CancellationToken cancellationToken)
    {
        var word = await _wordRepository.GetByIdAsync(request.Id);
        
        if (word == null)
            throw new CustomException($"Word with ID {request.Id} was not found.");

        return _mapper.Map<WordViewModel>(word);
    }
} 