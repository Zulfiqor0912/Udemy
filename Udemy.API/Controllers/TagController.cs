using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Tags.Commands.CrateTag;
using Udemy.Application.Tags.Commands.DeleteTag;
using Udemy.Application.Tags.Dto;
using Udemy.Application.Tags.Queries.GetAll;
using Udemy.Application.Tags.Queries.GetTagById;
using Udemy.Domain.Entities;

namespace Udemy.API.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
[Route("api/[controller]")]
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

    [HttpDelete("by-name/{name}")]
    public async Task<IActionResult> DeleteTagByName(string name)
    {
        var result = await mediator.Send(new DeleteTagCommand(name));
        return Ok(result);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetTagByName(string name)
    {
        var result = await mediator.Send(new GetTagByNameQuery(name));
        return Ok(result);
    }
}
