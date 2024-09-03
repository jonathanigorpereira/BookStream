namespace BookStream.Core.Entities;
public class AgeRating : BaseEntity
{
    public AgeRating(string description)
        :base()
    {
        Description = description;
    }

    public string Description { get; private set; }
}
