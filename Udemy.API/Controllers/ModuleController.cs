using MediatR;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Modules.Command.CreateModule;
using Udemy.Application.Modules.Command.RemoveModule;

namespace Udemy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModuleController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateModule(CreateModuleCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteModule(Guid id)
    {
        await mediator.Send(new RemoveModuleCommand(id));
        return Ok();
    }
}
