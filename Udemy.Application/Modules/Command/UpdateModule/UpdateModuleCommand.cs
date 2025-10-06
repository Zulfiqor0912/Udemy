using MediatR;
using System.Text.Json.Serialization;

namespace Udemy.Application.Modules.Command.UpdateModule;

public class UpdateModuleCommand(Guid id) : IRequest
{
    [JsonIgnore]
    public Guid Id { get; set; } = id;
    //Modul nomi (masalan: “Introduction to ASP.NET Core”).
    public string Title { get; set; } = default!;
    // Kurs ichidagi modul tartib raqami
    public int Order { get; set; }
    // Modul haqida qisqacha izoh
    public string? Description { get; set; }
}
