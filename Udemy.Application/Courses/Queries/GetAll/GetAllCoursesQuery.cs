using MediatR;
using Udemy.Application.Courses.Dtos;

namespace Udemy.Application.Courses.Queries.GetAll;

public class GetAllCoursesQuery : IRequest<IEnumerable<CourseDto>>
{
    public GetAllCoursesQuery()
    {

    }
}
