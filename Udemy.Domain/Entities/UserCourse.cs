namespace Udemy.Domain.Entities;

public class UserCourse
{
    //Kursga yozilgan foydalanuvchi.
    public Guid UserId { get; set; }

    public User User { get; set; }

    //Foydalanuvchi ro‘yxatdan o‘tgan kurs.
    public Guid CourseId { get; set; }

    public Course Course { get; set; }
}