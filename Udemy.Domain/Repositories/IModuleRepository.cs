using Udemy.Domain.Entities;

namespace Udemy.Domain.Repositories;

public interface IModuleRepository
{
    Task CreateModule(Module module);
    Task DeleteModule(Guid Id);
}
