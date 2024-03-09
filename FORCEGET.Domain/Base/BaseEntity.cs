namespace FORCEGET.Domain.Base;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }

    public long CreatedBy { get; set; }
}