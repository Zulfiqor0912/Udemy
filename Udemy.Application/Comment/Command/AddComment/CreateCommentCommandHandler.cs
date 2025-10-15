using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Comment.Command.AddComment;

public class CreateCommentCommandHandler(
    IMapper mapper,
    ILogger<CreateCommentCommandHandler> logger,
    ICommentRepository commentRepository) : IRequestHandler<CreateCommentCommand>
{
    public Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
            {
                logger.LogInformation("Maydonni to'ldiring");
                throw new ArgumentNullException(nameof(request));
            }

            var comment = mapper.Map<Domain.Entities.Comment>(request);

            if (comment is null)
            {
                logger.LogInformation("Barcha maydonlarni to'diriring");
                return Task.CompletedTask;
            }
            else
            {
                commentRepository.CreateCommentForCourse(comment);
                logger.LogInformation("Comment muvaffaqqiyatli yaratildi");
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
