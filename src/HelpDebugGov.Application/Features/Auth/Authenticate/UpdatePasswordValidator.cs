using FluentValidation;

namespace HelpDebugGov.Application.Features.Auth.Authenticate;

public class UpdatePasswordValidator : AbstractValidator<UpdatePasswordRequest>
{
    public UpdatePasswordValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Password).MinimumLength(8).MaximumLength(64)
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