using Microsoft.EntityFrameworkCore;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;
using Udemy.Infrastructure.Persistence;

namespace Udemy.Infrastructure.Repositories;

public class TagRepository(UdemyDbContext dbContext) : ITagRepository
{
    public async Task<bool> AddTag(Tag tag)
    {
        await dbContext.Tags.AddAsync(tag);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTagByName(string name)
    {
        var tag = await dbContext.Tags.FirstOrDefaultAsync(t => t.Name == name);
        if (tag is null) return false;
        else {
            dbContext.Tags.Remove(tag);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }

    public  async Task<IEnumerable<Tag>> GetAll()
    {
        var tags =  await dbContext.Tags.ToListAsync();
        return tags;
    }

    public async Task<Tag> GetTagByName(string name)
    {
        var tag = await dbContext.Tags.FirstOrDefaultAsync(t => t.Name == name);
        //if (tag == null)
        //{
        //    tag = new Tag { Name = name };
        //    dbContext.Tags.Add(tag);
        //    await dbContext.SaveChangesAsync();
        //}
        return tag;
    }
}
