using BookStream.Application.Models.ViewModels;
using BookStream.Core.Repositories;
using MediatR;

namespace BookStream.Application.Commands.AuthorCommands.InsertAuthor;
public class InsertAuthorHandler : IRequestHandler<InsertAuthorCommand, ResultViewModel<int>>
{
    private readonly IMediator _mediator;
    private readonly IAuthorRepository _authorRepository;
    public InsertAuthorHandler(IMediator mediator, IAuthorRepository authorRepository)
    {
        _mediator = mediator;
        _authorRepository = authorRepository;
    }

    public async Task<ResultViewModel<int>> Handle(InsertAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = request.ToEntity();

        var exists = await _authorRepository.ExistsByNameAsync(author.Name, cancellationToken);

        if (exists)
            return ResultViewModel<int>.Error("Este autor já está cadastrado.");

        await _authorRepository.AddAsync(author, cancellationToken);

        return ResultViewModel<int>.Success(author.Id);
    }
}
