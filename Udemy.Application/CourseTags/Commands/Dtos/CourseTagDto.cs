namespace Udemy.Application.CourseTags.Commands.Dtos;

public class CourseTagDto
{
    //Kurs teg(masalan: “.NET”, “Backend”, “Frontend”).
    public Guid TagId { get; set; }
    //Qaysi kursga tegishli.
    public Guid CourseId { get; set; }
}
