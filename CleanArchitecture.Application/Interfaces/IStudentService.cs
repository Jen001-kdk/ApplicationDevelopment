using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
    Task<StudentDto?> GetStudentByIdAsync(int id);
    // Add these two:
    Task UpdateStudentAsync(Student student);
    Task DeleteStudentAsync(int id);

    Task AddStudentAsync(Student student);
    Task<IEnumerable<StudentDto>> GetStudentsWithCoursesAsync();
}


