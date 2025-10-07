using Microsoft.EntityFrameworkCore;
using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;
using Udemy.Infrastructure.Persistence;

namespace Udemy.Infrastructure.Repositories;

public class ContentRepository(UdemyDbContext udemyDbContext) : IContentRepository
{
    public async Task CreateContent(Content content)
    {
        await udemyDbContext.AddAsync(content);
        await udemyDbContext.SaveChangesAsync();
    }

    public async Task DeleteContent(Guid id)
    {
        var content = await udemyDbContext.Contents.FindAsync(id);
        udemyDbContext.Contents.Remove(content!);
        await udemyDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Content>> GetAllContents()
    {
        var contents = await udemyDbContext.Contents.ToListAsync();
        return contents;
    }

    public async Task<Content> GetContentById(Guid id)
    {
        var content = await udemyDbContext.Contents.FindAsync(id);
        return content!;
    }

    public async Task UpdateContent(Content content)
    {
        udemyDbContext.Contents.Update(content);
        await udemyDbContext.SaveChangesAsync();
    }
}
