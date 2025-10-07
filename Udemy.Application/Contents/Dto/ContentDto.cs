namespace Udemy.Application.Contents.Dto;

public class ContentDto
{
    // Kontent nomi (masalan: "Lesson 1 - Introduction")
    public string Title { get; set; } = default!;
    // Video link  
    public string? UrlVideo { get; set; }
    // Rasm link
    public string? UrlImage { get; set; }
    public string? Text { get; set; }
    // Qaysi modulga tegishli
    public Guid ModuleId { get; set; }
}
