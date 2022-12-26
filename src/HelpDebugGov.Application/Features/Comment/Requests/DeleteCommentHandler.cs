namespace HelpDebugGov.Application.Features.Comments.Requests;

using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Features.Comments.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;

public class DeleteCommentHandler : IRequestHandler<DeleteCommentRequest, OneOf<bool, CommentNotFound>>
{
    private readonly IContext _context;

    public DeleteCommentHandler(IContext context)
    {
        _context = context;
    }

    public async Task<OneOf<bool, CommentNotFound>> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
    {
        var Comment = await _context.Comments
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (Comment is null) return new CommentNotFound();
        _context.Comments.Remove(Comment!);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}