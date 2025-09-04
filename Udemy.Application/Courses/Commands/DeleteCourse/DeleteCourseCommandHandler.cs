using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Exception;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Courses.Commands.DeleteCourse;

public class DeleteCourseCommandHandler(
    ICourseRepository courseRepository,
    ILogger<DeleteCourseCommandHandler> logger,
    IMapper mapper) : IRequestHandler<DeleteCourseCommand>
{
    public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
            {
                logger.LogInformation("O'chirmoqchi bo'lgan kursni tanlang");
                throw new ArgumentNullException(nameof(request));
            }
            var course = await courseRepository.GetCourseById(request.Id);
            if (course is null) throw new Exception("Bu course topilmadi");
            await courseRepository.DeleteCourse(course);
            logger.LogInformation("O'chirildi");
        }
        catch (Exception ex) {

        }
    }
}
