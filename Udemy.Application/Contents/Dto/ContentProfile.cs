using AutoMapper;
using Udemy.Application.Contents.Command.CreateContent;
using Udemy.Application.Contents.Command.UpdateContent;
using Udemy.Domain.Entities;

namespace Udemy.Application.Contents.Dto;

public class ContentProfile : Profile
{
    public ContentProfile() 
    {
        CreateMap<CreateContentCommand, Content>();
        CreateMap<UpdateContentCommand, Content>();
        CreateMap<Content, ContentDto>();
    }
}
