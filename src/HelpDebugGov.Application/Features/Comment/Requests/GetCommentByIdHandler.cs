// TODO: too many files in one directory.. refactor
namespace HelpDebugGov.Application.Features.Comments.Requests;

using AutoMapper;
using HelpDebugGov.Application.Common;
using HelpDebugGov.Application.Features.Comments.Requests;
using HelpDebugGov.Application.Features.Comments.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;

public class GetCommentByIdHandler : IRequestHandler<GetCommentByIdRequest, OneOf<GetCommentResponse, CommentNotFound>>
{
    private readonly IContext _context;
    private readonly IMapper _mapper;

    public GetCommentByIdHandler(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<OneOf<GetCommentResponse, CommentNotFound>> Handle(GetCommentByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _context.Comments
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (result is null) return new CommentNotFound();
        return _mapper.Map<GetCommentResponse>(result);
    }
}