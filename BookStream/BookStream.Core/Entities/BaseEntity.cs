namespace BookStream.Core.Entities;
public class BaseEntity
{
    public BaseEntity()
    {
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    public int Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsDeleted { get; private set; } 
    public void SetAsDelete() => IsDeleted = true;
}
