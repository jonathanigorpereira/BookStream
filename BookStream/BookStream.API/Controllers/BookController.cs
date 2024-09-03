using BookStream.Application.Commands.BookCommands.InsertBook;
using BookStream.Application.Queries.QueryBook.GetAll;
using BookStream.Application.Queries.QueryBook.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStream.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;
    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Listar todos os livros cadastrados
    /// </summary>
    /// <returns>Todos os livros cadastrados até o momento</returns>
    /// <response code="201">Success</response>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllBooksQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _mediator.Send(new GetBookByIdQuery(id));

        return Ok(book);
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Post(InsertBookCommand command)
    {
        var results = await _mediator.Send(command);

        if (!results.IsSuccess)
            return BadRequest(results.Message);

        return CreatedAtAction(nameof(GetById), new { id = results.Result }, command);
    }

    [HttpPut("{id}/Return")]
    public async Task<IActionResult>Put(int id)
    {
        return NoContent();
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return NoContent();
    }
}
