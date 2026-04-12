using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class InstructorRepository : IInstructorRepository
{
    private readonly ApplicationDbContext _context;
    public InstructorRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Instructor>> GetAllAsync() => await _context.Instructors.ToListAsync();
    public async Task<Instructor> GetByIdAsync(int id) => await _context.Instructors.FindAsync(id);
    public async Task AddAsync(Instructor instructor)
    {
        await _context.Instructors.AddAsync(instructor);
        await _context.SaveChangesAsync();
    }

    // Task 6 Logic: Count modules per instructor
    public async Task<IEnumerable<object>> GetInstructorModuleCountsAsync()
    {
        return await _context.Instructors
            .Select(i => new {
                InstructorName = i.FirstName + " " + i.LastName,
                ModuleCount = i.ModuleInstructors.Count
            }).ToListAsync();
    }
}