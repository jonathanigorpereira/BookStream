using BookStream.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStream.Application.Queries.QueryBook.GetAll;
public class GetAllBooksQuery : IRequest<ResultViewModel<List<BookItemViewModel>>>
{
}
