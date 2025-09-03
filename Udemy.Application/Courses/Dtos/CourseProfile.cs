using AutoMapper;
using Udemy.Application.Courses.Commands.CreateCourse;
using Udemy.Domain.Entities;

namespace Udemy.Application.Courses.Dtos;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseDto>();

        CreateMap<CreateCourseCommand, Course>();
    }
}
