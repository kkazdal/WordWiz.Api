using AutoMapper;
using WordWiz.Application.Common.ViewModels;
using WordWiz.Application.Features.Categories.Queries.GetAllCategories.ViewModels;
using WordWiz.Application.Features.Words.Queries.GetWordById.ViewModels;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Word, WordViewModel>();
        CreateMap<Question, QuestionViewModel>()
            .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category.Name))
            .ForMember(d => d.Choices, opt => opt.MapFrom(s => s.GetChoices()));
    }
}