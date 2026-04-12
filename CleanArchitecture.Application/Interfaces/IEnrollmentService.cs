using CleanArchitecture.Domain.Entities;


namespace CleanArchitecture.Application.Interfaces;

public interface IEnrollmentService
{
    Task<IEnumerable<Enrollment>> GetAllAsync();
    Task<IEnumerable<object>> GetEnrollmentDetailsAsync(); 
}
