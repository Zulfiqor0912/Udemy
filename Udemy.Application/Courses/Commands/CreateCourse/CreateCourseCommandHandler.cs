using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Courses.Commands.CreateCourse;

public class CreateCourseCommandHandler(
    ILogger<CreateCourseCommandHandler> logger,
    IMapper mapper,
    ICourseRepository courseRepository) : IRequestHandler<CreateCourseCommand>
{
    public async Task Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new Exception("Kiritilgan ma'lumotlar mos emas");
        }
        else {
            var course = mapper.Map<Course>(request);
            try
            {
                await courseRepository.CreateCourse(course);
                logger.LogInformation($"{course.Title} Yangi kurs yaratildi");
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                throw;
            }
        }
        
    }

}
