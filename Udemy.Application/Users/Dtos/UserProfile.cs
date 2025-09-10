using AutoMapper;
using Udemy.Application.Users.Commands.Register;
using Udemy.Domain.Entities;
namespace Udemy.Application.Users.Dtos;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<RegisterUserCommand, User>();
    }
}
