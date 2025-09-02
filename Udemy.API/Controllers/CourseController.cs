using MediatR;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application;
using Udemy.Application.Courses.Queries.GetAll;

namespace Udemy.API.Controllers;

[ApiController]
[Route("api/course/[controller]")]
public class CourseController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await mediator.Send(new GetAllCoursesQuery());
        return Ok(courses);
    }
}
