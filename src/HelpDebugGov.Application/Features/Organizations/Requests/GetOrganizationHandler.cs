namespace HelpDebugGov.Application.Features.Organizations.Requests;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Common.Responses;
using HelpDebugGov.Application.Extensions;
using HelpDebugGov.Domain.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetOrganizationsHandler : IRequestHandler<GetOrganizationsRequest, PaginatedList<Responses.GetOrganizationResponse>>
{
    private readonly IContext _context;

    private readonly IMapper _mapper;

    public GetOrganizationsHandler(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<PaginatedList<Responses.GetOrganizationResponse>> Handle(GetOrganizationsRequest request, CancellationToken cancellationToken)
    {
        var organizations = _context.Organizations.OrderBy(x => x.Id);
        return await _mapper.ProjectTo<Responses.GetOrganizationResponse>(organizations).ToPaginatedListAsync(request.CurrentPage, request.PageSize);
    }
}