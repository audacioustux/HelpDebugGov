namespace HelpDebugGov.Application.Features.Organizations.Requests;

using MediatR;
using OneOf;
using Responses;

public record DeleteOrganizationRequest(Guid Id) : IRequest<OneOf<bool, OrganizationNotFound>>;