﻿using BookStream.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStream.Application.Queries.QueryAuthor.GetAll;
public class GetAllAuthorsQuery:IRequest<ResultViewModel<List<AuthorViewModel>>>  
{
}
