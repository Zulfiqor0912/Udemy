using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Comment.Command.DeleteComment;

public class DeleteCommentCommandHandler(
    ILogger<DeleteCommentCommandHandler> logger,
    ICommentRepository commentRepository) : IRequestHandler<DeleteCommentCommand>
{
    public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
            {
                logger.LogInformation("Maydonni to'ldiring");
            }

            var comment = await commentRepository.GetCommentForCourse(request.CommentId);

            if (comment is null)
            {
                logger.LogInformation("Bunday comment Mavjud emas!");
            }
            await commentRepository.DeleteCommentForCourse(comment);
            logger.LogInformation("Comment muvaffaqqiyatli o'chirildi");
        }
        catch (Exception ex) 
        {
            logger.LogError(ex, "Nimadir xato ketdi");
            throw;
        }
    }
}
