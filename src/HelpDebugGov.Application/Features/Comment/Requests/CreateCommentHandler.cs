namespace HelpDebugGov.Application.Features.Comments.Requests;

using AutoMapper;
using BCrypt.Net;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Domain.Auth;
using HelpDebugGov.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Responses;

public class CreateCommentHandler : IRequestHandler<CreateCommentRequest, GetCommentResponse>
{
    private readonly IContext _context;
    private readonly IMapper _mapper;

    public CreateCommentHandler(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetCommentResponse> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
    {
        var issue = await _context.Issues.FirstAsync(x => x.Id == request.IssueId, cancellationToken);
        var user = await _context.Users.FirstAsync(x => x.Id == request.UserId, cancellationToken);
        // TODO: use automapper?
        var created = new Comment
        {
            User = user,
            Issue = issue,
            Text = request.Text,
            Status = request.Status
        };
        _context.Comments.Add(created);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<GetCommentResponse>(created);
    }
}