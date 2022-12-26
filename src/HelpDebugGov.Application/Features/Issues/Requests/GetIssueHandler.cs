namespace HelpDebugGov.Application.Features.Issues.Requests;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Common.Responses;
using HelpDebugGov.Application.Extensions;
using HelpDebugGov.Domain.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetIssuesHandler : IRequestHandler<GetIssuesRequest, PaginatedList<Responses.GetIssueResponse>>
{
    private readonly IContext _context;

    private readonly IMapper _mapper;

    public GetIssuesHandler(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<PaginatedList<Responses.GetIssueResponse>> Handle(GetIssuesRequest request, CancellationToken cancellationToken)
    {
        var issues = _context.Issues.OrderBy(x => x.Id);
        return await _mapper.ProjectTo<Responses.GetIssueResponse>(issues).ToPaginatedListAsync(request.CurrentPage, request.PageSize);
    }
}