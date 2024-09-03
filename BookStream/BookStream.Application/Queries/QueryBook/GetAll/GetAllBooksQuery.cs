using BookStream.Application.Models.ViewModels;
using MediatR;

namespace BookStream.Application.Queries.QueryBook.GetAll;
public class GetAllBooksQuery : IRequest<ResultViewModel<List<BookItemViewModel>>>
{
}
