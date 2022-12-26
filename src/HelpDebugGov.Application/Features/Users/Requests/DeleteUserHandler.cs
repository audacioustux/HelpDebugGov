namespace HelpDebugGov.Application.Features.Users.Requests;

using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Features.Users.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, OneOf<bool, UserNotFound>>
{
    private readonly IContext _context;

    public DeleteUserHandler(IContext context)
    {
        _context = context;
    }

    public async Task<OneOf<bool, UserNotFound>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (user is null) return new UserNotFound();
        _context.Users.Remove(user!);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}