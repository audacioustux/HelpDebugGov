namespace HelpDebugGov.Application.Features.Issues.Requests;

using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Features.Issues.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;

public class DeleteIssueHandler : IRequestHandler<DeleteIssueRequest, OneOf<bool, IssueNotFound>>
{
    private readonly IContext _context;

    public DeleteIssueHandler(IContext context)
    {
        _context = context;
    }

    public async Task<OneOf<bool, IssueNotFound>> Handle(DeleteIssueRequest request, CancellationToken cancellationToken)
    {
        var Issue = await _context.Issues
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (Issue is null) return new IssueNotFound();
        _context.Issues.Remove(Issue!);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}