using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Repositories;

namespace Udemy.Application.CourseTags.Commands.CreateTag;

public class CreateTagCommandHandler(
    ILogger<CreateTagCommandHandler> logger,
    IMapper mapper,
    ITagRepository tagRepository) : IRequestHandler<CreateTagCommand, bool>
{
    public Task<bool> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var 
    }
}
