using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Comment.Command.UpdateComment;

public class UpdateCommentCommandHandler(
    ILogger<UpdateCommentCommandHandler> logger,
    IMapper mapper,
    ICommentRepository commentRepository) : IRequestHandler<UpdateCommentCommand>
{
    public Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
            {
                logger.LogInformation("Maydonni to'ldiring");
                return Task.CompletedTask;
            }
            var c = commentRepository.GetCommentForCourse(request.Id);
            if (c is null)
            {
                logger.LogInformation("Bunday comment Mavjud emas!");
                return Task.CompletedTask;
            }
            else
            {
                var comment = mapper.Map<Domain.Entities.Comment>(request);

                if (comment is null)
                {
                    logger.LogInformation("Maydonni to'ldiring");
                    return Task.CompletedTask;
                }

                commentRepository.UpdateCommentForCourse(comment);
                return Task.CompletedTask;
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Nimadir xato ketdi");
            throw;
        }
    }
}
