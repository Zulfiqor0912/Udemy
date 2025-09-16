using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application;
using Udemy.Application.Courses.Commands.CreateCourse;
using Udemy.Application.Courses.Commands.DeleteCourse;
using Udemy.Application.Courses.Dtos;
using Udemy.Application.Courses.Queries.GetAll;
using Udemy.Application.Courses.Queries.GetCourseById;
using Udemy.Application.CourseTags.Commands.CreateCourseTag;
using Udemy.Domain.Constants;
using Udemy.Domain.Entities;

namespace Udemy.API.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
[Route("api/[controller]")]
public class CourseController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await mediator.Send(new GetAllCoursesQuery());
        return Ok(courses);
    }

    [Authorize(Roles = $"{UserRoles.Programmer},{UserRoles.Admin},{UserRoles.Teacher}")] //[Authorize(Roles = UserRoles.Programmer + "," + UserRoles.Admin + "," + UserRoles.Teacher)]
    [HttpPost]
    public async Task<IActionResult> CretaCourse(CreateCourseCommand courseCommand)
    {
        await mediator.Send(courseCommand);
        return Created();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
        await mediator.Send(new DeleteCourseCommand(id));
        return Ok();
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetCourseById(Guid id)
    {
        var course = await mediator.Send(new GetCourseByIdQuery(id));
        return Ok(course);
    }
}
