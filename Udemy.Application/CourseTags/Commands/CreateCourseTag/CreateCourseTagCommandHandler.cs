using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.CourseTags.Commands.CreateCourseTag;

public class CreateCourseTagCommandHandler(
    ILogger<CreateCourseTagCommandHandler> logger,
    ICourseTagRepository repository,
    IMapper mapper) : IRequestHandler<CreateCourseTagCommand>
{
    public async Task Handle(CreateCourseTagCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        try
        {
            var courseTag = mapper.Map<CourseTag>(request);
            await repository.AddCourseTag(courseTag);
            logger.LogInformation("Course tag muvaffaqqiyatli qo'shildi");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while creating a course tag.");
            throw;
        }
    }
}
