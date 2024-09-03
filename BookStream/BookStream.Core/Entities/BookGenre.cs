namespace BookStream.Core.Entities;
public class BookGenre : BaseEntity
{
    public BookGenre(string genre) : base()
    {
        Genre = genre;
    }

    public string Genre { get; private set; }
}
