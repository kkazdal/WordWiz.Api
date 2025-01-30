using FluentValidation;

namespace WordWiz.Application.Features.Words.Commands.CreateWord;

public class CreateWordCommandValidator : AbstractValidator<CreateWordCommand>
{
    public CreateWordCommandValidator()
    {
        RuleFor(v => v.Text)
            .NotEmpty().WithMessage("Text is required.")
            .MaximumLength(200).WithMessage("Text must not exceed 200 characters.");

        RuleFor(v => v.PartOfSpeech)
            .NotEmpty().WithMessage("Part of speech is required.")
            .MaximumLength(50).WithMessage("Part of speech must not exceed 50 characters.");

        RuleFor(v => v.Synonyms)
            .NotEmpty().WithMessage("Synonyms are required.")
            .MaximumLength(500).WithMessage("Synonyms must not exceed 500 characters.");

        RuleFor(v => v.Definition)
            .NotEmpty().WithMessage("Definition is required.")
            .MaximumLength(1000).WithMessage("Definition must not exceed 1000 characters.");
    }
} 