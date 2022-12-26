using FluentValidation;

namespace HelpDebugGov.Application.Features.Issues.Requests;

public class CreateIssueValidator : AbstractValidator<CreateIssueRequest>
{
    public CreateIssueValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Title).MinimumLength(15);
    }
}