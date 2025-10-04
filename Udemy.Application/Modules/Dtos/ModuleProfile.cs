using AutoMapper;
using Udemy.Application.Modules.Command.CreateModule;
using Udemy.Domain.Entities;

namespace Udemy.Application.Modules.Dtos;

public class ModuleProfile : Profile
{
    public ModuleProfile()
    {
        CreateMap<CreateModuleCommand, Module>();
    }
}
