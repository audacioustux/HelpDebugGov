// TODO: too many files in one directory.. refactor
namespace HelpDebugGov.Application.Features.Issues.Requests;

using AutoMapper;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Features.Issues.Requests;
using HelpDebugGov.Application.Features.Issues.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;

public class GetIssueByIdHandler : IRequestHandler<GetIssueByIdRequest, OneOf<GetIssueResponse, IssueNotFound>>
{
    private readonly IContext _context;
    private readonly IMapper _mapper;

    public GetIssueByIdHandler(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<OneOf<GetIssueResponse, IssueNotFound>> Handle(GetIssueByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _context.Issues
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (result is null) return new IssueNotFound();
        return _mapper.Map<GetIssueResponse>(result);
    }
}