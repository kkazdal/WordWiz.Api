using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WordWiz.Application.Features.Words.Commands.CreateWord;
using WordWiz.Application.Features.Words.Commands.DeleteWord;
using WordWiz.Application.Features.Words.Commands.UpdateWord;
using WordWiz.Application.Features.Words.Queries.GetAllWords;
using WordWiz.Application.Features.Words.Queries.GetWordById;
using WordWiz.WebApi.Hubs;

namespace WordWiz.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHubContext<NotificationHub> _hubContext;

    public WordsController(IMediator mediator, IHubContext<NotificationHub> hubContext)
    {
        _mediator = mediator;
        _hubContext = hubContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllWordsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _mediator.Send(new GetWordByIdQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateWordCommand command)
    {
        var wordId = await _mediator.Send(command);
        
        // Notify all clients about the new word
        await _hubContext.Clients.All.SendAsync("NewWordAdded", wordId);
        
        return CreatedAtAction(nameof(GetById), new { id = wordId }, wordId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdateWordCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await _mediator.Send(command);
        
        // Notify all clients about the updated word
        await _hubContext.Clients.All.SendAsync("WordUpdated", id);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _mediator.Send(new DeleteWordCommand(id));
        
        // Notify all clients about the deleted word
        await _hubContext.Clients.All.SendAsync("WordDeleted", id);
        
        return NoContent();
    }
} 