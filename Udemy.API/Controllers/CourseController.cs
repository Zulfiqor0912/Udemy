using Microsoft.AspNetCore.Mvc;
using Udemy.Application;

namespace Udemy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController(ICourseService courseService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var result = await courseService.GetAllCourses();
        return Ok(result);
    }
}
