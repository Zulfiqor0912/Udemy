using MediatR;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Modules.Command.CreateModule;
using Udemy.Application.Modules.Command.RemoveModule;
using Udemy.Application.Modules.Command.UpdateModule;
using Udemy.Application.Modules.Queries;

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

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateModule(Guid id, [FromBody] UpdateModuleCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetModule(Guid id) 
    {
        var module = await mediator.Send(new GetModuleByIdQuery(id));
        return Ok(module);
    }
}
