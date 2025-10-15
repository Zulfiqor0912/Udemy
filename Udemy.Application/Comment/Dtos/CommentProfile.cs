using AutoMapper;
using Udemy.Application.Comment.Command.AddComment;
using Udemy.Domain.Entities;

namespace Udemy.Application.Comment.Dtos;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<CreateCommentCommand, Domain.Entities.Comment>();
        CreateMap<Domain.Entities.Comment, CommentDto>();
    }
}
