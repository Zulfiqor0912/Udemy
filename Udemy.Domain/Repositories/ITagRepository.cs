using Udemy.Domain.Entities;

namespace Udemy.Domain.Repositories;

public interface ITagRepository
{
    Task<IEnumerable<Tag>> GetAll();
    Task<Tag> GetTagByName(string name);
    Task<bool> AddTag(Tag tag);
    Task<bool> DeleteTagByName(string name);

}
