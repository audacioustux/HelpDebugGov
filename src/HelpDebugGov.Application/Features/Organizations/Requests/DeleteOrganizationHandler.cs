namespace HelpDebugGov.Application.Features.Organizations.Requests;

using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Features.Organizations.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;

public class DeleteOrganizationHandler : IRequestHandler<DeleteOrganizationRequest, OneOf<bool, OrganizationNotFound>>
{
    private readonly IContext _context;

    public DeleteOrganizationHandler(IContext context)
    {
        _context = context;
    }

    public async Task<OneOf<bool, OrganizationNotFound>> Handle(DeleteOrganizationRequest request, CancellationToken cancellationToken)
    {
        var Organization = await _context.Organizations
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (Organization is null) return new OrganizationNotFound();
        _context.Organizations.Remove(Organization!);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}