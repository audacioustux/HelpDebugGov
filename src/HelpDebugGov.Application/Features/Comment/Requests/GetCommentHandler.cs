namespace HelpDebugGov.Application.Features.Comments.Requests;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Common.Responses;
using HelpDebugGov.Application.Extensions;
using HelpDebugGov.Domain.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetCommentsHandler : IRequestHandler<GetCommentsRequest, PaginatedList<Responses.GetCommentResponse>>
{
    private readonly IContext _context;

    private readonly IMapper _mapper;

    public GetCommentsHandler(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<PaginatedList<Responses.GetCommentResponse>> Handle(GetCommentsRequest request, CancellationToken cancellationToken)
    {
        var comments = _context.Comments.OrderBy(x => x.Id);
        return await _mapper.ProjectTo<Responses.GetCommentResponse>(comments).ToPaginatedListAsync(request.CurrentPage, request.PageSize);
    }
}