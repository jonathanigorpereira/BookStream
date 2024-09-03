using BookStream.Application.Models.ViewModels;
using MediatR;

namespace BookStream.Application.Queries.QueryBook.GetById;
public class GetBookByIdQuery : IRequest<ResultViewModel<BookItemViewModel>>
{
    public GetBookByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
