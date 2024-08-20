using BookStream.Application.Models.ViewModels;
using BookStream.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStream.Application.Queries.QueryBook.GetAll;
public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, ResultViewModel<List<BookItemViewModel>>>
{
    private readonly IBookRepository _bookRepository;
    public GetAllBooksHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<ResultViewModel<List<BookItemViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllAsync(cancellationToken);

        var model = books.Select(BookItemViewModel.FromEntity).ToList();

        return ResultViewModel<List<BookItemViewModel>>.Success(model);
    }
}
