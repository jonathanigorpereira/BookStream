using BookStream.Application.Models.ViewModels;
using BookStream.Core.Repositories;
using MediatR;

namespace BookStream.Application.Queries.QueryAuthor.GetAll;
public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, ResultViewModel<List<AuthorViewModel>>>
{
    private readonly IAuthorRepository _authorRepository;
    public GetAllAuthorsHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<ResultViewModel<List<AuthorViewModel>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _authorRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);

        var model = authors.Select(AuthorViewModel.FromEntity).ToList();

        return ResultViewModel<List<AuthorViewModel>>.Success(model);
    }
}
