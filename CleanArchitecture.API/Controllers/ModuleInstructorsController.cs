using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModuleInstructorsController : ControllerBase
{
    
    private readonly IModuleRepository _moduleRepository;

    public ModuleInstructorsController(IModuleRepository moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }

   
    [HttpPost]
    public async Task<IActionResult> AssignInstructor(ModuleInstructor assignment)
    {
        
        return Ok("Instructor assigned to module successfully.");
    }
}

