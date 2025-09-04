using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Application.Courses.Dtos;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Courses.Queries.GetCourseById;

public class GetCourseByIdQueryHandler(
    ICourseRepository courseRepository,
    ILogger<GetCourseByIdQueryHandler> logger,
    IMapper mapper) : IRequestHandler<GetCourseByIdQuery, CourseDto>
{
   public async Task<CourseDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var course = await courseRepository.GetCourseById(request.Id);
            if (course == null) throw new ArgumentNullException(nameof(course), "Topilmadi");
            var courseDto = mapper.Map<CourseDto>(course);
            return courseDto;
        }
        catch (Exception ex) 
        {
            logger.LogError(ex, "GetCourseByIdQuery ishlashida xatolik yuz berdi");
            throw;
        }
    }
}
