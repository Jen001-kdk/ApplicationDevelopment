using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _repo;
    public EnrollmentService(IEnrollmentRepository repo) => _repo = repo;

    public async Task<IEnumerable<Enrollment>> GetAllAsync() => await _repo.GetAllAsync();

    public async Task<IEnumerable<object>> GetEnrollmentDetailsAsync() 
    {
        
        return await _repo.GetEnrollmentDetailsAsync();
    }
}