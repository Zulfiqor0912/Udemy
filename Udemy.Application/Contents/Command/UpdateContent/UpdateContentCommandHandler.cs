using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Contents.Command.UpdateContent;

public class UpdateContentCommandHandler(
    ILogger<UpdateContentCommandHandler> logger,
    IMapper mapper,
    IContentRepository contentRepository) : IRequestHandler<UpdateContentCommand>
{
    public async Task Handle(UpdateContentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
            {
                logger.LogInformation("Maydonlarni to'ldiring");
            }

            var content = mapper.Map<Content>(request);
            await contentRepository.UpdateContent(content);
        }
        catch (Exception ex) 
        {
            logger.LogError(ex, "Nimadir xato ketdi");
        }
    }
}
