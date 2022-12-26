namespace HelpDebugGov.Application.Features.Organizations.Requests;

using MediatR;
using OneOf;
using Responses;

public record GetOrganizationByIdRequest(Guid Id) : IRequest<OneOf<GetOrganizationResponse, OrganizationNotFound>>;