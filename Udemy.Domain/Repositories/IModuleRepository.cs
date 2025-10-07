using Udemy.Domain.Entities;

namespace Udemy.Domain.Repositories;

public interface IModuleRepository
{
    Task CreateModule(Module module);
    Task DeleteModule(Guid Id);
    Task UpdateModule(Guid id, Module module);
    Task<Module> GetModuleById(Guid Id);
    Task<IEnumerable<Module>> GetAll();
}
