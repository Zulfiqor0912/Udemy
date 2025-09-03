using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Tags.Queries.GetAll;

public class GetAllTagQueryHandler(
    ITagRepository tagRepository,
    ILogger<GetAllTagQuery> logger) : IRequestHandler<GetAllTagQuery, IEnumerable<Tag>>
{
    public Task<IEnumerable<Tag>> Handle(GetAllTagQuery request, CancellationToken cancellationToken)
    {
        var tags = tagRepository.GetAll();
        if (tags is null)
        {
            logger.LogInformation("Tag hali qo'shilmagan");
            return Task.FromResult(Enumerable.Empty<Tag>());
        }
        else {
            logger.LogInformation("Taglar olinyapti");
            return tags;
        }
    }
}
