using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface IInstructorRepository
{
    Task<IEnumerable<Instructor>> GetAllAsync();
    Task<Instructor> GetByIdAsync(int id);
    Task AddAsync(Instructor instructor);

    Task<IEnumerable<object>> GetInstructorModuleCountsAsync();
}