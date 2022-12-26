namespace HelpDebugGov.Application.Features.Issues.Requests;

using System.ComponentModel.DataAnnotations;
using HelpDebugGov.Domain.Entities;
using MediatR;
using Responses;

public record CreateIssueRequest : IRequest<GetIssueResponse>
{
    [MaxLength(255)]
    public required string Title { get; set; }
    [MaxLength(4095)]
    public required string Description { get; set; }
    public required IssueStatus Status { get; set; }

    public required Guid UserId { get; set; }
    public required Guid OrganizationId { get; set; }
}