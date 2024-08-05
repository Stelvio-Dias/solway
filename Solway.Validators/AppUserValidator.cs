using Solway.Models;

using FluentValidation;

namespace Solway.Validators;

public class AppUserValidator : AbstractValidator<AppUser>
{
    public AppUserValidator()
    {
        RuleFor(appUser => appUser.FirstName).NotNull().NotEmpty().MinimumLength(2);
        RuleFor(appUser => appUser.LastName).NotNull().NotEmpty().MinimumLength(2);
        RuleFor(appUser => appUser.Email).NotNull().EmailAddress();
        RuleFor(appUser => appUser.PictureUrl).NotNull().MinimumLength(3);
        RuleFor(appUser => appUser.Password).NotNull().MinimumLength(3);
    }
}