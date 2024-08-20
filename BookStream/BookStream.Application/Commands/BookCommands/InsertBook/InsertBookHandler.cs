using BookStream.Application.Models.ViewModels;
using BookStream.Core.Repositories;
using MediatR;

namespace BookStream.Application.Commands.BookCommands.InsertBook;

public class InsertBookHandler : IRequestHandler<InsertBookCommand, ResultViewModel<int>>
{
    private readonly IMediator _mediator;
    private readonly IBookRepository _bookRepository;
    public InsertBookHandler(IMediator mediator, IBookRepository bookRepository)
    {
        _mediator = mediator;
        _bookRepository = bookRepository;
    }

    public async Task<ResultViewModel<int>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
    {

        var book = request.ToEntity();

        await _bookRepository.AddAsync(book, cancellationToken);

        return ResultViewModel<int>.Success(book.Id);
    }
}
