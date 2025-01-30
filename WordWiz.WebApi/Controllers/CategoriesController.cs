using MediatR;
using Microsoft.AspNetCore.Mvc;
using WordWiz.Application.Features.Categories.Commands.CreateCategory;
using WordWiz.Application.Features.Categories.Commands.DeleteCategory;
using WordWiz.Application.Features.Categories.Commands.UpdateCategory;
using WordWiz.Application.Features.Categories.Queries.GetAllCategories;
using WordWiz.Application.Features.Categories.Queries.GetCategoryById;

namespace WordWiz.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAllCategories")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(result);
    }

    [HttpGet("GetCategoryById")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery(id));
        return Ok(result);
    }

    [HttpPost("CreateCategory")]
    public async Task<IActionResult> Create(CreateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result }, result);
    }

    [HttpPut("UpdateCategory")]
    public async Task<IActionResult> Update(long id, UpdateCategoryCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("DeleteCategory")]
    public async Task<IActionResult> Delete(long id)
    {
        await _mediator.Send(new DeleteCategoryCommand(id));
        return NoContent();
    }
} 