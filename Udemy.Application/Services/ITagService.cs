using Udemy.Application.Tags.Commands.CrateTag;
using Udemy.Domain.Entities;

namespace Udemy.Application.Services;

public interface ITagService
{
    Task<CreateTagCommand> CreateTag(CreateTagCommand command);
    Task<IEnumerable<CreateTagCommand>> GetAllTags();
    Task<bool> DeleteTagAsync(string name);
    Task<Tag> GetTagByName(string name);

}
