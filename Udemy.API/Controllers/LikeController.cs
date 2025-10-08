using MediatR;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Likes.Command.PutOnTheLike;
using Udemy.Application.Likes.Command.RemoveLike;

namespace Udemy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LikeController(IMediator mediator) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> PutOnTheLike(Guid userId, Guid courseId)
    {
        await mediator.Send(new PutOnTheLikeCommand(userId, courseId));
        return Created();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemoveALike(Guid id)
    {
        await mediator.Send(new RemoveLikeCommand(id));
        return Ok();
    }
}
