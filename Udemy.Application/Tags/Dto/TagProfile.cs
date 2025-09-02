using AutoMapper;
using Udemy.Application.Tags.Commands.CrateTag;
using Udemy.Domain.Entities;

namespace Udemy.Application.Tags.Dto;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<TagDto, Tag>();
        CreateMap<CreateTagCommand, Tag>();
    }
}
