using BookStream.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStream.Application.Models.ViewModels;
public class AuthorViewModel
{
    public AuthorViewModel(int id, string name, DateTime birthDate, DateTime? deathDate, List<Book> books)
    {
        Id = id;
        Name = name;
        BirthDate = birthDate;
        DeathDate = deathDate;
        Books = books?.Select(b => b.Title).ToList() ?? new List<string>();
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime? DeathDate { get; private set; }
    public List<string> Books { get; private set; }

    public static AuthorViewModel FromEntity(Author author)
        => new(author.Id, author.Name, author.BirthDate, author.DeathDate, author.Books);
}
