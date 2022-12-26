namespace HelpDebugGov.Application.Features.Issues.Requests;

using AutoMapper;
using BCrypt.Net;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Domain.Auth;
using HelpDebugGov.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Responses;

public class CreateIssueHandler : IRequestHandler<CreateIssueRequest, GetIssueResponse>
{
    private readonly IContext _context;
    private readonly IMapper _mapper;

    public CreateIssueHandler(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetIssueResponse> Handle(CreateIssueRequest request, CancellationToken cancellationToken)
    {
        var organization = await _context.Organizations.FirstAsync(x => x.Id == request.OrganizationId, cancellationToken);
        var user = await _context.Users.FirstAsync(x => x.Id == request.UserId, cancellationToken);
        // TODO: use automapper?
        var created = new Issue
        {
            User = user,
            Organization = organization,
            Title = request.Title,
            Description = request.Description,
            Status = request.Status
        };
        _context.Issues.Add(created);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<GetIssueResponse>(created);
    }
}