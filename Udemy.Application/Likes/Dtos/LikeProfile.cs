using AutoMapper;
using Udemy.Application.Likes.Command.PutOnTheLike;
using Udemy.Domain.Entities;

namespace Udemy.Application.Likes.Dtos;

public class LikeProfile : Profile
{
    public LikeProfile()
    {
        CreateMap<PutOnTheLikeCommand, Like>();
    }
}
