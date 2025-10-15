using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Application.Comment.Dtos;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Comment.Queries.GetCommentForCourse;

public class GetCommentForCourseQueryHandler(
    IMapper mapper,
    ILogger<GetCommentForCourseQueryHandler> logger,
    ICommentRepository commentRepository) : IRequestHandler<GetCommentForCourseQuery, IEnumerable<CommentDto>>
{
    async Task<IEnumerable<CommentDto>> IRequestHandler<GetCommentForCourseQuery, IEnumerable<CommentDto>>.Handle(GetCommentForCourseQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var c = await commentRepository.GetCommentForCourse(request.Id);
            var comments = mapper.Map<IEnumerable<CommentDto>>(c);
            if (comments is null)
            {
                logger.LogInformation("Commentlar hali mavjud emas");
                throw new ArgumentException();
            }
            else
            {
                return comments;
            }
        }
        catch (Exception ex) 
        {
            logger.LogError(ex, "Nimadir xato ketdi!");
            return Enumerable.Empty<CommentDto>();
        }
    }
}
