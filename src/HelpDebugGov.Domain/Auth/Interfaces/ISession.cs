namespace HelpDebugGov.Domain.Auth.Interfaces;

public interface ISession
{
    public Guid UserId { get; }
    public DateTime Now { get; }
}