using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepo;

    public StudentService(IStudentRepository studentRepo)
    {
        _studentRepo = studentRepo;
    }


    public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
    {
        var students = await _studentRepo.GetAllAsync();
        return students.Select(s => new StudentDto
        {
            Id = s.Id,
            FullName = $"{s.FirstName} {s.LastName}",
            Email = s.Email
        }).ToList();
    }


    public async Task<StudentDto?> GetStudentByIdAsync(int id)
    {
        var student = await _studentRepo.GetByIdAsync(id);
        if (student == null) return null;
        return new StudentDto { Id = student.Id, FullName = $"{student.FirstName} {student.LastName}", Email = student.Email };
    }

   
    public async Task AddStudentAsync(Student student)
    {
        await _studentRepo.AddAsync(student);
    }

 
    public async Task UpdateStudentAsync(Student student)
    {
        await _studentRepo.UpdateAsync(student);
    }

   
    public async Task DeleteStudentAsync(int id)
    {
        await _studentRepo.DeleteAsync(id);
    }

   
    public async Task<IEnumerable<StudentDto>> GetStudentsWithCoursesAsync()
    {
        var students = await _studentRepo.GetStudentsWithCoursesAsync();
        return students.Select(s => new StudentDto
        {
            Id = s.Id,
            FullName = $"{s.FirstName} {s.LastName}",
            Email = s.Email
        }).ToList();
    }
}