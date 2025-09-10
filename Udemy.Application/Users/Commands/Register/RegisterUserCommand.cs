using MediatR;

namespace Udemy.Application.Users.Commands.Register;

public class RegisterUserCommand : IRequest
{
    //Har bir foydalanuvchining unikal identifikatori.
    public Guid Id { get; set; }

    //Foydalanuvchining ismi.
    public string FirstName { get; set; } = default!;

    //Foydalanuvchining familiyasi.
    public string LastName { get; set; } = default!;

    //Foydalanuvchining foydalanuvchi nomi (username).
    public string UserName { get; set; } = default!;

    //Foydalanuvchining elektron pochta manzili.
    public string Email { get; set; } = default!;
    //Foydalanuvchining parol hash qiymati.
    public string PasswordHash { get; set; } = default!;
}
