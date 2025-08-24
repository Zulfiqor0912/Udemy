namespace Udemy.Domain.Entities;

public class Content
{
    //Kontentning unikal identifikatori.
    public Guid Id { get; set; }

    //Kontent nomi (masalan: “Installing .NET SDK”).
    public string Title { get; set; } = default!;

    //Video darsning manzili.
    public string? VideoUrl { get; set; } = default!;

    //Matn ko‘rinishidagi material.
    public string? TextBody { get; set; } = default!;

    //Ushbu kontent qaysi modulga tegishli.
    public Guid ModuleId { get; set; }

    public Module Module { get; set; }
}