namespace Udemy.Domain.Entities;

public class Content
{
    public Guid Id { get; set; }

    // Kontent nomi (masalan: "Lesson 1 - Introduction")
    public string Title { get; set; } = default!;

    // Kontent turi (video, text, quiz, va hokazo)
    public string Type { get; set; } = default!;

    // Video link yoki matnli material
    public string? Url { get; set; }
    public string? Text { get; set; }

    // Qaysi modulga tegishli
    public Guid ModuleId { get; set; }
    public Module Module { get; set; } = default!;
}