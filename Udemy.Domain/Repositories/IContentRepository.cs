using Udemy.Domain.Entities;

namespace Udemy.Domain.Repositories;

public interface IContentRepository
{
    Task CreateContent(Content content);
    Task UpdateContent(Content content);
    Task DeleteContent(Guid id);
    Task<IEnumerable<Content>> GetAllContents();
    Task<Content> GetContentById(Guid id);
}
