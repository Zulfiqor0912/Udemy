using MediatR;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Tags.Commands.CrateTag;

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
}
