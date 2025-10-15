using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Application.Comment.Dtos;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Comment.Queries.GetCommentForCourse;

public class GetAllCommentForCourseQueryHandler(
    ILogger<GetAllCommentForCourseQueryHandler> logger,
    IMapper mapper,
    ICommentRepository commentRepository) : IRequestHandler<GetAllCommentForCourseQuery, IEnumerable<CommentDto>>
{
    public async Task<IEnumerable<CommentDto>> Handle(GetAllCommentForCourseQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var comments = await commentRepository.GetAllCommentsForCourse(request.Id);
            var c = mapper.Map<IEnumerable<CommentDto>>(comments);
            return c;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Nimadir xato ketdi!");
            return Enumerable.Empty<CommentDto>();
        }
    }
}
