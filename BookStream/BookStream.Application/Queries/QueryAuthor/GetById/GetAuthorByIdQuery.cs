using BookStream.Application.Models.ViewModels;
using MediatR;

namespace BookStream.Application.Queries.QueryAuthor.GetById;
public class GetAuthorByIdQuery : IRequest<ResultViewModel<AuthorViewModel>>
{
    public GetAuthorByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
