using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Contents.Command.CreateContent;

public class CreateContentCommandHandler(
    ILogger<CreateContentCommand> logger,
    IMapper mapper,
    IContentRepository contentRepository) : IRequestHandler<CreateContentCommand>
{
    public async Task Handle(CreateContentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
            {
                logger.LogInformation("Malumotlarni kiriting");
            }
            var content = mapper.Map<Content>(request);
            await contentRepository.CreateContent(content);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Nimadir xato ketdi");
        }
    }
}
