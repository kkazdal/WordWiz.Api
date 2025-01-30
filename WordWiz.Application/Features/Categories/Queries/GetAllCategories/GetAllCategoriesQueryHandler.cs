using AutoMapper;
using MediatR;
using WordWiz.Application.Features.Categories.Queries.GetAllCategories.ViewModels;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryViewModel>>
{
    private readonly IRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(IRepository<Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
    }
} 