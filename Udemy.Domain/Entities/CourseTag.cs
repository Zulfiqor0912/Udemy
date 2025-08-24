namespace Udemy.Domain.Entities;

public class CourseTag
{
    public Guid Id { get; set; }
    //Kurs teg(masalan: “.NET”, “Backend”, “Frontend”).
    public string Tag { get; set; }
    //Qaysi kursga tegishli.
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
}