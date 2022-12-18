using FluentValidation;

namespace HelpDebugGov.Application.Features.Auth.Authenticate;

public class CreateUserValidator : AbstractValidator<RegisterUserRequest>
{
    public CreateUserValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Handle).MaximumLength(24).MinimumLength(3)
            .Matches(@"^(?![_.])")
                .WithMessage("Handle cannot start with underscore or dot")
            .Matches(@"^(?!.*[_.]{2}).+$")
                .WithMessage("Handle cannot contain consecutive underscores or dots")
            .Matches(@"(?=.*[a-z])")
                .WithMessage("Handle must contain at least one Alphabet")
            .Matches(@"^[a-z0-9_.]+$")
                .WithMessage("Handle can only contain lowercase letters, numbers, underscores and dots")
            .Matches(@"(?<![_.])$")
                .WithMessage("Handle cannot end with underscore or dot");

        RuleFor(x => x.Email).NotEmpty().MaximumLength(255).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(255)
            .Matches(@"^(?=.*[a-z])")
                .WithMessage("Password must contain at least one lowercase letter")
            .Matches(@"^(?=.*[A-Z])")
                .WithMessage("Password must contain at least one uppercase letter")
            .Matches(@"^(?=.*[0-9])")
                .WithMessage("Password must contain at least one number")
            .Matches(@"^(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?])")
                .WithMessage("Password must contain at least one special character");
    }
}