using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;
using Udemy.Infrastructure.Persistence;

namespace Udemy.Infrastructure.Repositories;

public class LikeRepository(UdemyDbContext udemyDbContext) : ILikeRepository
{
    public async Task<Like> GetLikeById(Guid id)
    {
       var like = await udemyDbContext.Likes.FindAsync(id);
        return like!;
    }

    public async Task PressALike(Like like)
    {
        await udemyDbContext.Likes.AddAsync(like);
        await udemyDbContext.SaveChangesAsync();
    }

    public async Task RemoveALike(Like like)
    {
        udemyDbContext.Likes.Remove(like);
        await udemyDbContext.SaveChangesAsync();
    }


}
