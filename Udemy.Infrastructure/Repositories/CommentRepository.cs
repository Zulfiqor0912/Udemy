using Microsoft.EntityFrameworkCore;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;
using Udemy.Infrastructure.Persistence;

namespace Udemy.Infrastructure.Repositories;

internal class CommentRepository(UdemyDbContext udemyDbContext) : ICommentRepository
{
    public async Task CreateCommentForCourse(Comment comment)
    {
        await udemyDbContext.Comments.AddAsync(comment);
        await udemyDbContext.SaveChangesAsync();
    }

    public async Task DeleteCommentForCourse(Comment comment)
    {
        udemyDbContext.Comments.Remove(comment);
        await udemyDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Comment>> GetAllCommentsByUserForCourse(Guid courseId, Guid userId)
    {
        var comments = await udemyDbContext.Comments
            .Where(c => c.CourseId == courseId && c.UserId == userId)
            .Include(c => c.User)
            .Include(c => c.Course)
            .ToListAsync();
        return comments;
    }

    public async Task<IEnumerable<Comment>> GetAllCommentsForCourse(Guid courseId)
    {
        var comments = await udemyDbContext.Comments
            .Where(c => c.CourseId == courseId)
            .Include(c => c.User)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
        return comments;
    }

    public async Task<Comment> GetCommentForCourse(Guid commentId)
    {
        var comment = await udemyDbContext.Comments.FindAsync(commentId);
        return comment;
    }

    public async Task UpdateCommentForCourse(Comment comment)
    {
        udemyDbContext.Comments.Update(comment);
        await udemyDbContext.SaveChangesAsync();
    }
}
