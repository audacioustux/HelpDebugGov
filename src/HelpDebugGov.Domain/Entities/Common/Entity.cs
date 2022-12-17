namespace HelpDebugGov.Domain.Entities.Common;

public abstract class Entity
{
    public virtual Guid Id { get; set; } = default!;
}