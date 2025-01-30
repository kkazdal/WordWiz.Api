using MediatR;
using Microsoft.AspNetCore.Mvc;
using WordWiz.Application.Features.Questions.Commands.CreateQuestion;
using WordWiz.Application.Features.Questions.Commands.DeleteQuestion;
using WordWiz.Application.Features.Questions.Commands.UpdateQuestion;
using WordWiz.Application.Features.Questions.Queries.GetAllQuestions;
using WordWiz.Application.Features.Questions.Queries.GetQuestionById;

namespace WordWiz.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuestionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllQuestionsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _mediator.Send(new GetQuestionByIdQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateQuestionCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdateQuestionCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _mediator.Send(new DeleteQuestionCommand(id));
        return NoContent();
    }
} 