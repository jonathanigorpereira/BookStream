using BookStream.Application.Models.ViewModels;
using BookStream.Core.Repositories;
using MediatR;

namespace BookStream.Application.Queries.QueryBook.GetById;
public class GetBookByIdHandler:IRequestHandler<GetBookByIdQuery, ResultViewModel<BookItemViewModel>>
{
    private readonly IBookRepository _bookRepository;
    public GetBookByIdHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<ResultViewModel<BookItemViewModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetByIdAsync(request.Id, cancellationToken);

        if (books is null)
            return ResultViewModel<BookItemViewModel>.Error("O Livro não faz parte do acervo desta biblioteca.");

        var model = BookItemViewModel.FromEntity(books);

        return ResultViewModel<BookItemViewModel>.Success(model);
    }
}
