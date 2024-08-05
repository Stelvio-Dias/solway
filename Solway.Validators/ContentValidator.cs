using Solway.Models;

using FluentValidation;

namespace Solway.Validators;

public class ContentValidator : AbstractValidator<Content>
{
    public ContentValidator()
    {
        RuleFor(content => content.ContentURL).NotEmpty().MinimumLength(3);
        RuleFor(content => content.Description).NotEmpty();
    }
}