using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Application.Contents.Dto;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Contents.Queries.GetContentById;

public class GetContentByIdQueryHandler(
    ILogger<GetContentByIdQueryHandler> logger,
    IMapper mapper,
    IContentRepository contentRepository) : IRequestHandler<GetContentByIdQuery, ContentDto>
{
    public async Task<ContentDto> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var content = await contentRepository.GetContentById(request.Id);
            var contentDto = mapper.Map<ContentDto>(content);
            return contentDto;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Nimadir xato ketdi");
            throw;
        }
    }
}
