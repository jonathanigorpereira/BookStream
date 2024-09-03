using BookStream.Application.Commands.AuthorCommands.InsertAuthor;
using BookStream.Application.Queries.QueryAuthor.GetAll;
using BookStream.Application.Queries.QueryAuthor.GetById;
using BookStream.Application.Queries.QueryBook.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStream.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllAuthorsQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var author = await _mediator.Send(new GetAuthorByIdQuery(id));

        return Ok(author);
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Post(InsertAuthorCommand command)
    {
        var results = await _mediator.Send(command);

        if (!results.IsSuccess)
            return BadRequest(results.Message);

        return CreatedAtAction(nameof(GetById), new { id = results.Result }, command);
    }
}
