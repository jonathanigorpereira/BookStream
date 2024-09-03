using BookStream.Application.Models.ViewModels;
using BookStream.Core.Entities;
using MediatR;

namespace BookStream.Application.Commands.AuthorCommands.InsertAuthor;
public class InsertAuthorCommand : IRequest<ResultViewModel<int>>
{
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public bool Active { get; set; }
    public Author ToEntity()
       => new(Name, BirthDate, DeathDate, Active);
}
