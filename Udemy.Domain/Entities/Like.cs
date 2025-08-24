namespace Udemy.Domain.Entities;

public class Like
{
    public Guid Id { get; set; }
    //Like bosgan foydalanuvchi.
    public Guid UserId { get; set; }
    public User User { get; set; }
    //Like qilingan kurs.
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
}