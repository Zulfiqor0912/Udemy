using MediatR;

namespace Udemy.Application.Courses.Commands.CreateCourse;

public class CreateCourseCommand : IRequest
{
    //Kurs nomi (masalan: “C# asoslari”).
    public string Title { get; set; } = default!;

    //Kurs tavsifi, mazmuni.
    public string Description { get; set; } = default!;
    //Kursni yaratgan foydalanuvchining IDsi.
    public Guid CreatedById { get; set; }
    //Kursning narxi (masalan: 49.99$).
    public decimal Price { get; set; }
}
