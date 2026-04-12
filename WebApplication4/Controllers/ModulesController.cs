using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Interfaces;


namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly ICourseRepository _courseRepository;
        public ModulesController(IModuleRepository moduleRepository, ICourseRepository courseRepository)
        {
            _moduleRepository = moduleRepository;
            _courseRepository = courseRepository;
        }

        // 1. GET: api/modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Module>>> GetModules()
        {
            var modules = await _moduleRepository.GetAllAsync();
            return Ok(modules);
        }

        // 2. GET: api/modules/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Module>> GetModule(int id)
        {
            var module = await _moduleRepository.GetByIdAsync(id);
            if (module == null) return NotFound();
            return Ok(module);
        }

        // 3. POST: api/modules
        [HttpPost]
        public async Task<ActionResult<Module>> PostModule(Module module)
        {
            // Requirement: Check if Course exists using CourseRepository
            var course = await _courseRepository.GetByIdAsync(module.CourseId);
            if (course == null) return BadRequest("Invalid CourseId. The course does not exist.");

            await _moduleRepository.AddAsync(module);
            return CreatedAtAction(nameof(GetModule), new { id = module.Id }, module);
        }

        // 4. GET: api/modules/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetModuleCount()
        {
            var modules = await _moduleRepository.GetAllAsync();
            return Ok(modules.Count());
        }

        // 5. GET: api/modules/high-credit
        [HttpGet("high-credit/{creditValue}")]
        public async Task<ActionResult<IEnumerable<Module>>> GetHighCreditModules(int creditValue)
        {
            var modules = await _moduleRepository.GetAllAsync();
            var highCredit = modules.Where(m => m.Credits > creditValue);
            return Ok(highCredit);
        }

        // 6. POST: api/modules/bulk (Bulk insert modules)
        [HttpPost("bulk")]
        public async Task<ActionResult<IEnumerable<Module>>> PostBulkModules(List<Module> modules)
        {
            // Clean way: We tell the repository to add each module
            foreach (var module in modules)
            {
                await _moduleRepository.AddAsync(module);
            }

            return Ok(modules);
        }
    }
}