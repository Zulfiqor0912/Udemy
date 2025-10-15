using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Application.Comment.Dtos;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Comment.Queries.GetAllCommentsByUserForCourse;

public class GetAllCommentsByUserForCourseQueryHandler(
    ILogger<GetAllCommentsByUserForCourseQueryHandler> logger,
    IMapper mapper,
    ICommentRepository commentRepository) : IRequestHandler<GetAllCommentsByUserForCourseQuery, IEnumerable<CommentDto>>
{
    async Task<IEnumerable<CommentDto>> IRequestHandler<GetAllCommentsByUserForCourseQuery, IEnumerable<CommentDto>>.Handle(GetAllCommentsByUserForCourseQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null)
            {
                logger.LogInformation("Maydonni to'ldiring");
                return Enumerable.Empty<CommentDto>();
            }
            var c = await commentRepository.GetAllCommentsByUserForCourse(request.CourseId, request.UserId);
            if (c == null)
            {
                logger.LogInformation("Commenr mavjud emas");
                return Enumerable.Empty<CommentDto>();
            }
            else
            {
                var comment = mapper.Map<IEnumerable<CommentDto>>(c);
                return comment;
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Nimadir xato ketdi");
            throw;
        }
    }
}
