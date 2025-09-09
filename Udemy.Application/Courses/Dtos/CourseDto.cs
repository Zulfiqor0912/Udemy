using Udemy.Application.Tags.Dto;
using Udemy.Application.Users.Dtos;
using Udemy.Domain.Entities;

namespace Udemy.Application.Courses.Dtos;

public class CourseDto
{
    //Kursning unikal identifikatori.
    public Guid Id { get; set; }

    //Kurs nomi (masalan: “C# asoslari”).
    public string Title { get; set; } = default!;

    //Kurs tavsifi, mazmuni.
    public string Description { get; set; } = default!;
    //Kursning o‘rtacha reytingi (1–5).
    public double AvarageRating { get; set; }
    //Kursga yozilgan studentlar soni.
    public int NumberOfStudents { get; set; }
    //Kursni yaratgan foydalanuvchining IDsi.
    public Guid CreatedById { get; set; }

    //Kursni yaratgan foydalanuvchi obyekti.
    public UserDto CreatedBy { get; set; } = default!;
    //Kursning narxi (masalan: 49.99$).
    public decimal Price { get; set; }

    public List<TagDto> Tags { get; set; } = new();
}
