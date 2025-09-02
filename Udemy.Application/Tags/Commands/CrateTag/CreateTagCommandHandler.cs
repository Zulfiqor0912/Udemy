using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Tags.Commands.CrateTag;

public class CreateTagCommandHandler(
    ITagRepository tagRepository,
    ILogger<CreateTagCommandHandler> logger,
    IMapper mapper) : IRequestHandler<CreateTagCommand, bool>
{
    public async Task<bool> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            logger.LogInformation($"{request.Name} taglar ro'yhatiga qo'shilmadi");
            return false;
        }
        var tag = mapper.Map<Tag>(request);
        try
        {
            await tagRepository.AddTag(tag);
            logger.LogInformation("'{TagName}' taglar ro'yhatiga qo'shildi", request.Name);
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "'{TagName}' tag qo'shishda xato yuz berdi", request.Name);
            return false;
        }
    }
}
