using Udemy.Domain.Entities;

namespace Udemy.Domain.Repositories;

public interface ILikeRepository
{
    Task PressALike(Like like);
    Task RemoveALike(Like like);
    Task<Like> GetLikeById(Guid id);
}
