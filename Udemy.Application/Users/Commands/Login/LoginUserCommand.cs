﻿using MediatR;

namespace Udemy.Application.Users.Commands.Login;

public class LoginUserCommand : IRequest<string>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
