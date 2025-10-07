using MediatR;
using Udemy.Application.Contents.Dto;

namespace Udemy.Application.Contents.Queries.GetContentById;

public class GetContentByIdQuery(Guid id) : IRequest<ContentDto>
{
    public Guid Id { get; set; } = id;
}
