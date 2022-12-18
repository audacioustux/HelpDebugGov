using FluentValidation;

namespace HelpDebugGov.Application.Features.Auth.Authenticate;

public class CreateUserValidator : AbstractValidator<RegisterUserRequest>
{
    public CreateUserValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Handle).MaximumLength(24).MinimumLength(3);
        RuleFor(x => x.Handle).Matches(@"^(?![_.])")
            .WithMessage("Handle cannot start with underscore or dot");
        RuleFor(x => x.Handle).Matches(@"^(?!.*[_.]{2}).+$")
            .WithMessage("Handle cannot contain consecutive underscores or dots");
        RuleFor(x => x.Handle).Matches(@"(?=.*[a-z])")
            .WithMessage("Handle must contain at least one Alphabet");
        RuleFor(x => x.Handle).Matches(@"^[a-z0-9_.]+$")
            .WithMessage("Handle can only contain lowercase letters, numbers, underscores and dots");
        RuleFor(x => x.Handle).Matches(@"(?<![_.])$")
            .WithMessage("Handle cannot end with underscore or dot");

        RuleFor(x => x.Email).NotEmpty().MaximumLength(255).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(255);
    }
}