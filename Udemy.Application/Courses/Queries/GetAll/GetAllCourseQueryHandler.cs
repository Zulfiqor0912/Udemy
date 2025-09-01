using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Application.Courses.Dtos;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Courses.Queries.GetAll;

public class GetAllCourseQueryHandler(
    ILogger<GetAllCourseQueryHandler> logger,
    IMapper mapper,
    ICourseRepository courseRepository) : IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseDto>>
{
    public async Task<IEnumerable<CourseDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Barcha kurslar olindi");
        var result = await courseRepository.GetAllAsyn();
        var courseDtos = mapper.Map<IEnumerable<CourseDto>>(result);
        return courseDtos;
    }
}
