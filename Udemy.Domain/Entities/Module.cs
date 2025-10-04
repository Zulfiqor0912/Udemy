namespace Udemy.Domain.Entities;

public class Module
{
    //Modulning unikal identifikatori.
    public Guid Id { get; set; }
    //Modul nomi (masalan: “Introduction to ASP.NET Core”).
    public string Title { get; set; } = default!;
    //Ushbu moduldagi darslar (video va matnli materiallar).
    public ICollection<Content> Contents { get; set; } = new List<Content>();
    //Qaysi kursga tegishliligini bildiradi.
    public Guid CourseId { get; set; }
    public Course Course { get; set; } = default!;
    // Kurs ichidagi modul tartib raqami
    public int Order { get; set; }
    // Modul haqida qisqacha izoh
    public string? Description { get; set; }  
}