using BookStream.Application.Models.ViewModels;
using BookStream.Application.Queries.QueryBook.GetById;
using BookStream.Core.Repositories;
using MediatR;

namespace BookStream.Application.Queries.QueryAuthor.GetById;
internal class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, ResultViewModel<AuthorViewModel>>
{
    private readonly IAuthorRepository _authorRepository;
    public GetAuthorByIdHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<ResultViewModel<AuthorViewModel>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var books = await _authorRepository.GetByIdAsync(request.Id, cancellationToken);

        if (books is null)
            return ResultViewModel<AuthorViewModel>.Error("O Livro não faz parte do acervo desta biblioteca.");

        var model = AuthorViewModel.FromEntity(books);

        return ResultViewModel<AuthorViewModel>.Success(model);
    }
}

