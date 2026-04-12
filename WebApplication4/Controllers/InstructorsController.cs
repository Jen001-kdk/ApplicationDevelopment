using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication4.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorsController : ControllerBase
{
    private readonly IInstructorRepository _instructorRepo;

    public InstructorsController(IInstructorRepository instructorRepo)
    {
        _instructorRepo = instructorRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Instructor>>> GetInstructors() => Ok(await _instructorRepo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Instructor>> GetInstructor(int id)
    {
        var instructor = await _instructorRepo.GetByIdAsync(id);
        if (instructor == null) return NotFound();
        return Ok(instructor);
    }

    [HttpPost]
    public async Task<ActionResult<Instructor>> PostInstructor(Instructor instructor)
    {
        await _instructorRepo.AddAsync(instructor);
        return CreatedAtAction(nameof(GetInstructor), new { id = instructor.Id }, instructor);
    }

    [HttpGet("count")]
    public async Task<ActionResult<int>> GetInstructorCount()
    {
        var instructors = await _instructorRepo.GetAllAsync();
        return Ok(instructors.Count());
    }

   
    [HttpGet("distinct-hireyear")]
    public async Task<ActionResult<IEnumerable<int>>> GetDistinctHireYears()
    {
        var instructors = await _instructorRepo.GetAllAsync();
        return Ok(instructors.Select(i => i.HireDate.Year).Distinct());
    }
}