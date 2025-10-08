using MediatR;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Repositories;

namespace Udemy.Application.Likes.Command.RemoveLike;

public class RemoveLikeCommandHandler(
    ILogger<RemoveLikeCommandHandler> logger,
    ILikeRepository likeRepository) : IRequestHandler<RemoveLikeCommand, bool>
{
    async Task<bool> IRequestHandler<RemoveLikeCommand, bool>.Handle(RemoveLikeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
            {
                logger.LogWarning("Id ni kiriting");
                return false;
            }
            var like = await likeRepository.GetLikeById(request.Id);
            if (like is null)
            {
                logger.LogWarning("Bunday id li like mavjud emas");
                return false;
            }
            await likeRepository.RemoveALike(like);
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Xatolik yuz berdi");
            throw;
        }
    }
}
