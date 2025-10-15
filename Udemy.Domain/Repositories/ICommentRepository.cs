using Udemy.Domain.Entities;

namespace Udemy.Domain.Repositories;

public interface ICommentRepository
{
    Task CreateCommentForCourse(Comment comment);
    Task DeleteCommentForCourse(Comment comment);
    Task<Comment> GetCommentForCourse(Guid commentId);
    Task UpdateCommentForCourse(Comment comment);
    Task<IEnumerable<Comment>> GetAllCommentsForCourse(Guid courseId);
    Task<IEnumerable<Comment>> GetAllCommentsByUserForCourse(Guid courseId, Guid userId);
}
