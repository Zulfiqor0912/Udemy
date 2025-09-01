namespace Udemy.Domain.Entities;

public class CourseTag
{
    //Kurs teg(masalan: “.NET”, “Backend”, “Frontend”).
    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
    //Qaysi kursga tegishli.
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
}