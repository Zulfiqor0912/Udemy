using MediatR;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Contents.Command.CreateContent;
using Udemy.Application.Contents.Command.DeleteContent;
using Udemy.Application.Contents.Command.UpdateContent;
using Udemy.Application.Contents.Queries.GetAllContents;
using Udemy.Application.Contents.Queries.GetContentById;

namespace Udemy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContentController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateContent([FromBody] CreateContentCommand command)
    {
        await mediator.Send(command);
        return Created();
    }

    [HttpGet("allContents")]
    public async Task<IActionResult> GetAllContents()
    {
        var contents = await mediator.Send(new GetAllContentsQuery());
        return Ok(contents);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetContentById(Guid id)
    {
        var content = await mediator.Send(new GetContentByIdQuery(id));
        return Ok(content);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateContent(Guid id, [FromBody] UpdateContentCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteContent(Guid id)
    {
        await mediator.Send(new DeleteContentCommand(id));
        return Ok();
    }
}
