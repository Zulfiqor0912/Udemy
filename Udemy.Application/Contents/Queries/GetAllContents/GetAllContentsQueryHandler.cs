using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Application.Contents.Dto;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Contents.Queries.GetAllContents;

public class GetAllContentsQueryHandler(
    ILogger<GetAllContentsQueryHandler> logger,
    IMapper mapper,
    IContentRepository contentRepository) : IRequestHandler<GetAllContentsQuery, IEnumerable<ContentDto>>
{
    public async Task<IEnumerable<ContentDto>> Handle(GetAllContentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var content = await contentRepository.GetAllContents();
            var contentDto = mapper.Map<IEnumerable<ContentDto>>(content);
            return contentDto;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Nimadir xato ketdi");
            throw;
        }
    }
}
