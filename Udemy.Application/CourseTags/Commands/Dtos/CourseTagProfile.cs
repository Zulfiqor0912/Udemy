using AutoMapper;
using Udemy.Application.CourseTags.Commands.CreateCourseTag;
using Udemy.Domain.Entities;

namespace Udemy.Application.CourseTags.Commands.Dtos;

public class CourseTagProfile : Profile
{
    public CourseTagProfile()
    {
        CreateMap<CourseTagDto, CourseTag>();
        CreateMap<CreateCourseTagCommand, CourseTag>();
    }
}
