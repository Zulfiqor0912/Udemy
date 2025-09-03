using MediatR;
using Udemy.Domain.Entities;

namespace Udemy.Application.Tags.Queries.GetTagById;

public class GetTagByNameQuery(string name) : IRequest<Tag>
{
    public string TagName { get; set; } = name;
}
