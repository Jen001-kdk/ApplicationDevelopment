using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface IInstructorService
{
    Task<IEnumerable<Instructor>> GetAllAsync();

  
    Task<IEnumerable<object>> GetInstructorStatsAsync();
}