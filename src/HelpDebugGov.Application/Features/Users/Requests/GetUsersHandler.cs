namespace HelpDebugGov.Application.Features.Users.Requests;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Common.Responses;
using HelpDebugGov.Application.Extensions;
using HelpDebugGov.Domain.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, PaginatedList<Responses.GetUserResponse>>
{
    private readonly IContext _context;

    private readonly IMapper _mapper;

    public GetUsersHandler(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<PaginatedList<Responses.GetUserResponse>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        var users = _context.Users
            .WhereIf(!string.IsNullOrEmpty(request.Email), x => EF.Functions.Like(x.Email, $"%{request.Email}%")).OrderBy(x => x.Id);
        // .WhereIf(request.IsAdmin, x => x.Role == Roles.Admin);
        return await _mapper.ProjectTo<Responses.GetUserResponse>(users).ToPaginatedListAsync(request.CurrentPage, request.PageSize);
    }
}