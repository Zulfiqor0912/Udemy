using MediatR;
using Udemy.Domain.Entities;

namespace Udemy.Application.Modules.Command.CreateModule;

public class CreateModuleCommand : IRequest<Guid>
{
    //Modul nomi (masalan: “Introduction to ASP.NET Core”).
    public string Title { get; set; } = default!;
    //Qaysi kursga tegishliligini bildiradi.
    public Guid CourseId { get; set; }
    // Kurs ichidagi modul tartib raqami
    public int Order { get; set; }
    // Modul haqida qisqacha izoh
    public string? Description { get; set; }
}
