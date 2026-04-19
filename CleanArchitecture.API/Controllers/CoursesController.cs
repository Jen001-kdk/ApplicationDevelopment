using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private readonly ICourseService _courseService; 

       
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }


       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

       
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            await _courseService.AddAsync(course);
            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

 
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCourseCount()
        {
           
            var courses = await _courseService.GetAllAsync();
            return Ok(courses.Count());
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null) return NotFound();

            
            await _courseService.DeleteAsync(id);
            return NoContent();
        }
    }
}

