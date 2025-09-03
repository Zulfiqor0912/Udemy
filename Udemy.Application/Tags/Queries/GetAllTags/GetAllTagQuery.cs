using MediatR;
using Udemy.Application.Tags.Dto;
using Udemy.Domain.Entities;

namespace Udemy.Application.Tags.Queries.GetAll;

public class GetAllTagQuery : IRequest<IEnumerable<Tag>>
{
    public GetAllTagQuery()
    {
        
    }
}
