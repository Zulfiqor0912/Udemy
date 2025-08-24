namespace Udemy.Domain.Entities;

public class Rating
{
    public Guid Id { get; set; }
    public int Value { get; set; } // 1–5 oralig‘ida
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
}