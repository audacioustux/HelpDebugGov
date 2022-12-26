// TODO: too many files in one directory.. refactor
namespace HelpDebugGov.Application.Features.Organizations.Requests;

using AutoMapper;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Features.Organizations.Requests;
using HelpDebugGov.Application.Features.Organizations.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;

public class GetOrganizationByIdHandler : IRequestHandler<GetOrganizationByIdRequest, OneOf<GetOrganizationResponse, OrganizationNotFound>>
{
    private readonly IContext _context;
    private readonly IMapper _mapper;

    public GetOrganizationByIdHandler(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<OneOf<GetOrganizationResponse, OrganizationNotFound>> Handle(GetOrganizationByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _context.Organizations
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (result is null) return new OrganizationNotFound();
        return _mapper.Map<GetOrganizationResponse>(result);
    }
}