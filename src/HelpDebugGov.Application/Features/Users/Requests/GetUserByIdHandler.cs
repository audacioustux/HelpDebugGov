// TODO: too many files in one directory.. refactor
namespace HelpDebugGov.Application.Features.Users.Requests;

using AutoMapper;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Features.Users.Requests;
using HelpDebugGov.Application.Features.Users.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, OneOf<GetUserResponse, UserNotFound>>
{
    private readonly IContext _context;
    private readonly IMapper _mapper;

    public GetUserByIdHandler(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<OneOf<GetUserResponse, UserNotFound>> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (result is null) return new UserNotFound();
        return _mapper.Map<GetUserResponse>(result);
    }
}