using BookStream.Core.Entities;

namespace BookStream.Application.Models.ViewModels;
public class BookItemViewModel
{
    public BookItemViewModel(int id,
                             string code,
                             string title,
                             string synopsis,
                             string author,
                             string publisher,
                             string genre,
                             string isbn,
                             int yearOfPublication,
                             string ageRating)
    {
        Id = id;
        Code = code;
        Title = title;
        Synopsis = synopsis;
        Author = author;
        Publisher = publisher;
        Genre = genre;
        ISBN = isbn;
        YearOfPublication = yearOfPublication;
        AgeRating = ageRating;
    }

    public int Id { get; private set; }
    public string Code { get; private set; }
    public string Title { get; private set; }
    public string Synopsis { get; private set; }
    public string Author { get; private set; }
    public string Publisher { get; private set; }
    public string Genre { get; private set; }
    public string ISBN { get; private set; }
    public int YearOfPublication { get; private set; }
    public string AgeRating { get; private set; }

    public static BookItemViewModel FromEntity(Book book)
        => new(book.Id, book.Code, book.Title, book.Synopsis, book.Author.Name,
              book.Publisher, book.Genre.Genre, book.UnformatedISBN, book.YearOfPublication, book.AgeRating.Description);
}
