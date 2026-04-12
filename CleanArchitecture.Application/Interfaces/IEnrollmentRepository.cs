using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface IEnrollmentRepository
{
    Task<IEnumerable<Enrollment>> GetAllAsync();
    Task<Enrollment> GetByIdAsync(int id);
    Task AddAsync(Enrollment enrollment);
    Task DeleteAsync(int id);
    
    Task<IEnumerable<object>> GetEnrollmentDetailsAsync();
}