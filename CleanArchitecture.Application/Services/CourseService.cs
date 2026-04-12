using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepo;

    public CourseService(ICourseRepository courseRepo)
    {
        _courseRepo = courseRepo;
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _courseRepo.GetAllAsync();
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _courseRepo.GetByIdAsync(id);
    }

    public async Task AddAsync(Course course)
    {
        await _courseRepo.AddAsync(course);
    }

    public async Task DeleteAsync(int id)
    {
        await _courseRepo.DeleteAsync(id);
    }
}
