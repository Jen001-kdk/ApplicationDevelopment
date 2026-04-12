
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllAsync(); 
    Task<Course?> GetByIdAsync(int id);

    Task AddAsync(Course course);
    Task DeleteAsync(int id);
}



