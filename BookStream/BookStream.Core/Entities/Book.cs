using BookStream.Core.Enums;

namespace BookStream.Core.Entities;

public class Book : BaseEntity
{
    protected Book()
    {

    }

    public Book(string code,
                string title,
                string synopsis,
                string author,
                string publisher,
                int idGenre,
                string iSBN,
                int yearOfPublication,
                int idAgeRating) : base()
    {
        Code = code;
        Title = title;
        Synopsis = synopsis;
        Author = author;
        Publisher = publisher;
        IdGenre = idGenre;
        UnformatedISBN = iSBN;
        YearOfPublication = yearOfPublication;
        IdAgeRating = idAgeRating;
    }

    public string Code { get; private set; }
    public string Title { get; private set; }
    public string Synopsis { get; private set; }
    public string Author { get; private set; }
    public string Publisher { get; private set; }
    public int IdGenre { get; private set; }
    public BookGenre Genre { get; private set; }
    public string UnformatedISBN { get; private set; }
    public int YearOfPublication { get; private set; }
    public int IdAgeRating { get; private set; }
    public AgeRating AgeRating { get; private set; }
}
