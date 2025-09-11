using Microsoft.AspNetCore.Identity;
using System.Data.Common;

namespace Udemy.Domain.Entities;

public class User : IdentityUser<Guid>
{

    //Foydalanuvchining ismi.
    public string FirstName { get; set; } = default!;

    //Foydalanuvchining familiyasi.
    public string LastName { get; set; } = default!;

    //Foydalanuvchi yaratgan kurslar (Instructor bo‘lsa).
    public ICollection<Course> CreatedCourses { get; set; }

    //Foydalanuvchi ro‘yxatdan o‘tgan kurslar (Student bo‘lsa).
    public ICollection<UserCourse> RegisteredCourses { get; set; }

    //Foydalanuvchiga bildirilgan Commentlar
    public ICollection<Comment> Comments { get; set; }
    //Foydalanuvchiga berilgan Ratinglar
    public ICollection<Rating> Ratings { get; set; }

    //Foydalanuvchiga berilgan Likelar
    public ICollection<Like> Likes { get; set; }

}