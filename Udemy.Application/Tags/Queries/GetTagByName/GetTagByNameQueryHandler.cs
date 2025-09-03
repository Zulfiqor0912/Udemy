using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Exception;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Tags.Queries.GetTagById;

public class GetTagByNameQueryHandler(
    ITagRepository tagRepository,
    ILogger<GetTagByNameQueryHandler> logger) : IRequestHandler<GetTagByNameQuery, Tag>
{
    public async Task<Tag> Handle(GetTagByNameQuery request, CancellationToken cancellationToken)
    {
        var tag = await tagRepository.GetTagByName(request.TagName);
        if (tag is null) throw new NotFoundException(nameof(Tag), request.TagName);
        return tag;
    }
}
