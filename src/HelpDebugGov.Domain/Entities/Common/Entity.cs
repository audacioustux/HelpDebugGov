namespace HelpDebugGov.Domain.Entities.Common;

public abstract class Entity
{
    public virtual Guid Id { get; set; } = default!;

    public DateTime CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }
	public DateTime? DeletedAt { get; set; }
}