using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;

public class InstructorService : IInstructorService
{
    private readonly IInstructorRepository _repo;
    public InstructorService(IInstructorRepository repo) => _repo = repo;

    public async Task<IEnumerable<Instructor>> GetAllAsync() => await _repo.GetAllAsync();

    public async Task<IEnumerable<object>> GetInstructorStatsAsync()
    {
        
        return await _repo.GetInstructorModuleCountsAsync();
    }
}