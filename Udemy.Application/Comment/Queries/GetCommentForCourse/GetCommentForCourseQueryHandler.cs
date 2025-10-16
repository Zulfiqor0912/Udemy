using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Application.Comment.Dtos;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Comment.Queries.GetCommentForCourse;

public class GetCommentForCourseQueryHandler(
    IMapper mapper,
    ILogger<GetCommentForCourseQueryHandler> logger,
    ICommentRepository commentRepository) : IRequestHandler<GetCommentForCourseQuery, CommentDto>
{
    async Task<CommentDto> IRequestHandler<GetCommentForCourseQuery, CommentDto>.Handle(GetCommentForCourseQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var c = await commentRepository.GetCommentForCourse(request.Id);
            var comment = mapper.Map<CommentDto>(c);
            if (comment is null)
            {
                logger.LogInformation("Commentlar hali mavjud emas");
                throw new ArgumentException();
            }
            else
            {
                return comment;
            }
        }
        catch (Exception ex) 
        {
            logger.LogError(ex, "Nimadir xato ketdi!");
            throw;
        }
    }
}
