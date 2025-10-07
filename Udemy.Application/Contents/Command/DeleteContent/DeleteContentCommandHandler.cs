using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Contents.Command.DeleteContent;

public class DeleteContentCommandHandler(
    ILogger<DeleteContentCommandHandler> logger,
    IContentRepository contentRepository) : IRequestHandler<DeleteContentCommand>
{
    public async Task Handle(DeleteContentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) logger.LogInformation("Malumotlarni kiriting");
            await contentRepository.DeleteContent(request.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Nimadir xato ketdi");
        }
    }
}
