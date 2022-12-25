using FluentValidation;

namespace HelpDebugGov.Application.Features.Users.Requests;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Handle).MinimumLength(3)
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

        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).MinimumLength(8).MaximumLength(63)
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