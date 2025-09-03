using MediatR;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Tags.Commands.CrateTag;
using Udemy.Application.Tags.Commands.DeleteTag;
using Udemy.Application.Tags.Dto;
using Udemy.Application.Tags.Queries.GetAll;
using Udemy.Domain.Entities;

namespace Udemy.API.Controllers;

[ApiController]
[Route("api/tag")]
public class TagController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateNewTag(CreateTagCommand command)
    {
        var tag = await mediator.Send(command);
        return Ok(tag);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTags()
    {
        var tags = await mediator.Send(new GetAllTagQuery());
        return Ok(tags);
    }

    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteTagByName(string name)
    {
        var result = await mediator.Send(new DeleteTagCommand(name));
        return Ok(result);
    }
}
