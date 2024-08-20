using BookStream.Application.Models.ViewModels;
using BookStream.Core.Entities;
using BookStream.Core.Enums;
using MediatR;

namespace BookStream.Application.Commands.BookCommands.InsertBook;
public class InsertBookCommand : IRequest<ResultViewModel<int>>
{
    public string Code { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Synopsis { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public int IdGenre { get; set; }
    public string UnformatedISBN { get; set; } = string.Empty;
    public int YearOfPublication { get; set; }
    public int IdAgeRating { get; set; }

    public string FormattedISBN => FormatISBN(UnformatedISBN);

    public string FormatISBN(string unformattedISBN)
    {
        unformattedISBN = unformattedISBN.Replace("-", "").Replace(" ", "");

        string isbnFormatted = string.Empty;

        if (unformattedISBN.Length == 10)
        {
            // Formato para ISBN-10: 1-234-56789-X
            isbnFormatted = string.Concat("ISBN ", $"{unformattedISBN.Substring(0, 1)}-{unformattedISBN.Substring(1, 3)}-{unformattedISBN.Substring(4, 5)}-{unformattedISBN.Substring(9, 1)}");
        }
        else if (unformattedISBN.Length == 13)
        {
            // Formato para ISBN-13: 978-1-234-56789-0
            isbnFormatted = string.Concat("ISBN ", $"{unformattedISBN.Substring(0, 3)}-{unformattedISBN.Substring(3, 1)}-{unformattedISBN.Substring(4, 3)}-{unformattedISBN.Substring(7, 5)}-{unformattedISBN.Substring(12, 1)}");
        }

        return isbnFormatted;
    }

    public Book ToEntity()
        => new(Code, Title, Synopsis, Author, Publisher, IdGenre, FormattedISBN, YearOfPublication, IdAgeRating);
}
