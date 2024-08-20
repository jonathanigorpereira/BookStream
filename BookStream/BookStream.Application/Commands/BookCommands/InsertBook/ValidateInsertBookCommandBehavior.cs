using BookStream.Application.Models.ViewModels;
using BookStream.Core.Repositories;
using BookStream.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStream.Application.Commands.BookCommands.InsertBook
{
    public class ValidateInsertBookCommandBehavior :
        IPipelineBehavior<InsertBookCommand, ResultViewModel<int>>
    {
        private readonly IBookRepository _BookRepository;
        public ValidateInsertBookCommandBehavior(IBookRepository bookRepository)
        {
            _BookRepository = bookRepository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertBookCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var bookExist = await _BookRepository.ExistsForTitleAsync(request.Title,cancellationToken);

            if (bookExist)
            {
                return ResultViewModel<int>.Error("Este livro já está cadastrado na plataforma.");
            }
            return await next();
        }
    }
}
