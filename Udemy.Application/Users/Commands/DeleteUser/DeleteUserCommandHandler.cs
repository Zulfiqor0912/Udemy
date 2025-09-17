using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Udemy.Domain.Entities;

namespace Udemy.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler(
    UserManager<User> userManager,
    ILogger<DeleteUserCommandHandler> logger) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            logger.LogError("Id ni to'ldiring");
            throw new ArgumentNullException(nameof(request));
        }

        try
        {
            var user = await userManager.FindByIdAsync(request.Id.ToString());
            if (user is null)
            {
                logger.LogError("Bunday foydalanuvchi mavjud emas");
                throw new ArgumentNullException(nameof(user));
            }
            await userManager.DeleteAsync(user);
            logger.LogInformation("Foydalanuvchi muvaffaqiyatli o'chirildi");
            throw new Exception("Foydalanuvchi muvaffaqiyatli o'chirildi");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Foydalanuvchini o'chirishda xatolik yuz berdi");
            throw;
        }
    }
}
