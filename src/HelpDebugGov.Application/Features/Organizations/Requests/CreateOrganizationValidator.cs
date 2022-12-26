using FluentValidation;

namespace HelpDebugGov.Application.Features.Organizations.Requests;

public class CreateOrganizationValidator : AbstractValidator<CreateOrganizationRequest>
{
    public CreateOrganizationValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Name).MinimumLength(3);
    }
}