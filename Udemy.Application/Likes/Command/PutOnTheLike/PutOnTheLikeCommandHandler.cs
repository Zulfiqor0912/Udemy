using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Likes.Command.PutOnTheLike;

public class PutOnTheLikeCommandHandler(
    ILogger<PutOnTheLikeCommandHandler> logger,
    ILikeRepository likeRepository,
    IMapper mapper) : IRequestHandler<PutOnTheLikeCommand, bool>
{
    public async Task<bool> Handle(PutOnTheLikeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null) 
            {
                logger.LogWarning("Id ni kiriting");
                return false;
            }

            var like = mapper.Map<Like>(request);
            await likeRepository.PressALike(like);
            return true;
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.InnerException?.Message);
            throw;
        }
    }
}
