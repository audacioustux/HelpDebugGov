namespace HelpDebugGov.Domain.Auth;

public interface ISession
{
    public Guid UserId { get; }
    public DateTime Now { get; }
}