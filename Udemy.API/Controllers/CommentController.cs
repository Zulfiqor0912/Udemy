using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Udemy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController(IMediator mediator) : ControllerBase
{

}
