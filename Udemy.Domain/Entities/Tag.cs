namespace Udemy.Domain.Entities;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public ICollection<CourseTag> CourseTags { get; set; } = new List<CourseTag>();
}
