using AutoMapper;
using MediatR;
using WordWiz.Application.Common.Exceptions;
using WordWiz.Application.Features.Categories.Queries.GetCategoryById.ViewModels;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryViewModel>
{
    private readonly IRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(IRepository<Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryViewModel> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category == null)
            throw new CustomException($"Category with ID {request.Id} not found.");

        return new CategoryViewModel
        {
            Id = category.Id,
            Name = category.Name
        };
    }
} 