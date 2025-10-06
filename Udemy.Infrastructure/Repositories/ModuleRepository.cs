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

    public async Task<Module> GetModuleById(Guid Id)
    {
        var module = await udemyDbContext.Modules.FindAsync(Id);
        return module;
    }

    public async Task UpdateModule(Guid id, Module module)
    {
        var existingModule = await udemyDbContext.Modules.FindAsync(id);
        if (existingModule is null)
            throw new Exception($"Module with Id {id} not found");

        // faqat kerakli propertylarni yangilaymiz:
        existingModule.Title = module.Title;
        existingModule.Description = module.Description;
        existingModule.Order = module.Order;

        // CourseId ni o‘zgartirish shart bo‘lmasa, teginma
        // existingModule.CourseId = module.CourseId;

        await udemyDbContext.SaveChangesAsync();
    }
}
