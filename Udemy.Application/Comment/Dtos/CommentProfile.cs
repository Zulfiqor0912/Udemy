using AutoMapper;
using Udemy.Application.Comment.Command.AddComment;
using Udemy.Application.Users.Dtos;
using Udemy.Domain.Entities;

namespace Udemy.Application.Comment.Dtos;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        //CreateMap<User, UserDto>();
        CreateMap<CreateCommentCommand, Domain.Entities.Comment>();
        CreateMap<Domain.Entities.Comment, CommentDto>()
            .ForMember(dest => dest.UserDto, opt => opt.MapFrom(src => src.User));
    }
}
