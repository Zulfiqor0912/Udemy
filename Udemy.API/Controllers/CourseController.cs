using MediatR;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application;
using Udemy.Application.Courses.Commands.CreateCourse;
using Udemy.Application.Courses.Commands.DeleteCourse;
using Udemy.Application.Courses.Dtos;
using Udemy.Application.Courses.Queries.GetAll;
using Udemy.Application.Courses.Queries.GetCourseById;
using Udemy.Application.CourseTags.Commands.CreateCourseTag;
using Udemy.Domain.Entities;

namespace Udemy.API.Controllers;

[ApiController]
[Route("api/course")]
public class CourseController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await mediator.Send(new GetAllCoursesQuery());
        return Ok(courses);
    }

    [HttpPost]
    public async Task<IActionResult> CretaCourse(CreateCourseCommand courseCommand, CreateCourseTagCommand tagCommand)
    {
        await mediator.Send(courseCommand);
        await mediator.Send(tagCommand);
        return Created();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
        await mediator.Send(new DeleteCourseCommand(id));
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCourseById(Guid id)
    {
        var course = await mediator.Send(new GetCourseByIdQuery(id));
        return Ok(course);
    }
}
