using Solway.Models;

using FluentValidation;

namespace Solway.Validators;

public class MediaTypeValidator : AbstractValidator<MediaType>
{
    public MediaTypeValidator()
    {
        RuleFor(mediaType => mediaType.Id).NotNull().NotEmpty();
        RuleFor(mediaType => mediaType.Name).NotNull().NotEmpty().MinimumLength(2);
    }
}