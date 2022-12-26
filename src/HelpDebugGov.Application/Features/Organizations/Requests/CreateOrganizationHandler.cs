namespace HelpDebugGov.Application.Features.Organizations.Requests;

using AutoMapper;
using BCrypt.Net;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Domain.Auth;
using HelpDebugGov.Domain.Entities;
using MediatR;
using Responses;

public class CreateOrganizationHandler : IRequestHandler<CreateOrganizationRequest, GetOrganizationResponse>
{
    private readonly IContext _context;
    private readonly IMapper _mapper;

    public CreateOrganizationHandler(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetOrganizationResponse> Handle(CreateOrganizationRequest request, CancellationToken cancellationToken)
    {
        var created = _mapper.Map<Organization>(request);
        _context.Organizations.Add(created);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<GetOrganizationResponse>(created);
    }
}