using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface IModuleRepository
{
    // We use the full name CleanArchitecture.Domain.Entities.Module 
    // just in case it's confused with other "Modules"
    Task<IEnumerable<CleanArchitecture.Domain.Entities.Module>> GetAllAsync();
    Task<CleanArchitecture.Domain.Entities.Module> GetByIdAsync(int id);
    Task AddAsync(CleanArchitecture.Domain.Entities.Module module);
}