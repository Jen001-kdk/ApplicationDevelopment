using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class ModuleRepository : IModuleRepository
{
    private readonly ApplicationDbContext _context;
    public ModuleRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Module>> GetAllAsync() => await _context.Modules.ToListAsync();
    public async Task<Module> GetByIdAsync(int id) => await _context.Modules.FindAsync(id);
    public async Task AddAsync(Module module)
    {
        await _context.Modules.AddAsync(module);
        await _context.SaveChangesAsync();
    }
}