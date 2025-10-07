using MediatR;
using Udemy.Application.Contents.Dto;
using Udemy.Domain.Entities;

namespace Udemy.Application.Contents.Queries.GetAllContents;

public class GetAllContentsQuery : IRequest<IEnumerable<ContentDto>>
{
    public GetAllContentsQuery() { }
}
