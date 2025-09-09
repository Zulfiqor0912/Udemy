using AutoMapper;
using Udemy.Application.Courses.Commands.CreateCourse;
using Udemy.Application.Tags.Dto;
using Udemy.Domain.Entities;

namespace Udemy.Application.Courses.Dtos;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseDto>();

        CreateMap<Course, CourseDto>()
            .ForMember(dest => dest.Tags,
            opt => opt.MapFrom(src => src.CourseTags
            .Select(ct => new TagDto
            {
                Id = ct.Tag.Id,
                Name = ct.Tag.Name
            }).ToList()));

        CreateMap<CreateCourseCommand, Course>();
    }
}
