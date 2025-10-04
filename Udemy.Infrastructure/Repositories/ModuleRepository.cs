using Udemy.Domain.Entities;
using Udemy.Domain.Repositories;
using Udemy.Infrastructure.Persistence;

namespace Udemy.Infrastructure.Repositories;

public class ModuleRepository(UdemyDbContext udemyDbContext) : IModuleRepository
{
    public async Task CreateModule(Module module)
    {
        await udemyDbContext.Modules.AddAsync(module);
        await udemyDbContext.SaveChangesAsync();
    }

    public async Task DeleteModule(Guid Id)
    {
        var module = await udemyDbContext.Modules.FindAsync(Id);
        udemyDbContext.Modules.Remove(module);
        await udemyDbContext.SaveChangesAsync();
    }
}
