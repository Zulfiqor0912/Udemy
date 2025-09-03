using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Tags.Commands.DeleteTag;

public class DeleteTagComandHandler(
    ITagRepository tagRepository,
    ILogger<DeleteTagComandHandler> logger) : IRequestHandler<DeleteTagCommand, bool>
{
    public async Task<bool> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await tagRepository.DeleteTagByName(request.Name);
        if (tag)
        {
            logger.LogInformation($"Tag o'chirildi {request.Name}");
            return true;
        }
        else {
            logger.LogInformation($"Tag topilmadi {request.Name}");
            return false;
        }
    }
}
