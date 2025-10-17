using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Comment.Command.AddComment;
using Udemy.Application.Comment.Command.DeleteComment;
using Udemy.Application.Comment.Command.UpdateComment;
using Udemy.Application.Comment.Dtos;
using Udemy.Application.Comment.Queries.GetAllCommentsByUserForCourse;
using Udemy.Application.Comment.Queries.GetCommentForCourse;

namespace Udemy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController(IMediator mediator) : ControllerBase
{
    [HttpPost("course/{courseId:guid}/user/{userId:guid}")]
    public async Task<IActionResult> CreateComment(Guid courseId, Guid userId, [FromBody] string text)
    {
        var comment = new CreateCommentCommand
        {
            CourseId = courseId,
            UserId = userId,
            Text = text
        };
        await mediator.Send(comment);
        return Created();
    }

    [HttpDelete("{commentId:guid}")]
    public async Task<IActionResult> DeleteComment(Guid commentId)
    {
        await mediator.Send(new DeleteCommentCommand(commentId));
        return Ok();
    }

    [HttpGet("{commentId:guid}")]
    public async Task<IActionResult> GetComment(Guid commentId)
    {
        var comment = await mediator.Send(new GetCommentForCourseQuery(commentId));
        return Ok(comment);
    }

    [HttpPut("{commentId:guid}")]
    public async Task<IActionResult> UpdateComment(Guid commentId, [FromBody] string newText)
    {
        await mediator.Send(new UpdateCommentCommand(commentId, newText));
        return Ok();
    }

    [HttpGet("course/{courseid:guid}")]
    public async Task<IActionResult> GetAllCommentsForCourse(Guid courseid)
    {
        var comments = await mediator.Send(new GetAllCommentForCourseQuery(courseid));
        return Ok(comments);
    }

    [HttpGet("course/{courseId:guid}/user/{userId:guid}")]
    public async Task<IActionResult> GetAllCommentsByUserForCourse(Guid courseId, Guid userId)
    {
        var comments = await mediator.Send(new GetAllCommentsByUserForCourseQuery(courseId, userId));
        return Ok(comments);
    }
}
