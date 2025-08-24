namespace Udemy.Domain.Entities;

public class Course
{
    //Kursning unikal identifikatori.
    public Guid Id { get; set; }

    //Kurs nomi (masalan: “C# asoslari”).
    public string Title { get; set; } = default!;

    //Kurs tavsifi, mazmuni.
    public string Description { get; set; } = default!;

    //Kursga berilgan like soni.
    public int Likes { get; set; }

    //Kursga yozilgan kommentlar ro‘yxati.
    public ICollection<Comment> Comments { get; set; }

    //Kursning o‘rtacha reytingi (1–5).
    public double AvarageRating { get; set; }

    //Kursga berilgan barcha individual reytinglar ro‘yxati.
    public ICollection<Rating> Ratings { get; set; }

    //Kursning bo‘limlari va ularga tegishli darslarni tartib bilan ko‘rsatish uchun.
    public ICollection<Module> Modules { get; set; }

    //Kursga yozilgan studentlar soni.
    public int NumberOfStudents { get; set; }

    //Kursga teglar (taglar) qo‘shish (masalan: “Backend”, “C#”).
    public ICollection<CourseTag> Tags { get; set; }

    //Kursni yaratgan foydalanuvchining IDsi.
    public Guid CreatedById { get; set; }

    //Kursni yaratgan foydalanuvchi obyekti.
    public User CreatedBy { get; set; } = default!;

    //Kursning narxi (masalan: 49.99$).
    public decimal Price { get; set; }
}