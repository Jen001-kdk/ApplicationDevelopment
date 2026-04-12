using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // We call the Service now, not the Repo
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            // Use the Service, not the Repository
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null) return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> PostStudent(Student student)
        {
            // You will eventually move this logic into the Service too.
            // For now, to clear the red line:
            await _studentService.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id) return BadRequest();

            // FIXED: Use the Service here
            await _studentService.UpdateStudentAsync(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
          
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();

          
            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }


        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCount()
        {
           
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students.Count());
        }

        [HttpGet("with-courses")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetWithCourses()
        {
           
            var result = await _studentService.GetStudentsWithCoursesAsync();
            return Ok(result);
        }


        [HttpPost("bulk")]
        public async Task<ActionResult<IEnumerable<Student>>> PostBulk(List<Student> students)
        {
            foreach (var student in students)
            {
                // FIXED: Use the correct method name from your service
                await _studentService.AddStudentAsync(student);
            }
            return Ok(students);
        }

        // 9. GET: api/students/full-details (Multi-table join)
        [HttpGet("full-details")]
        public async Task<ActionResult<IEnumerable<object>>> GetFullDetails()
        {
            // For now, let's use the same method. 
            // In Clean Architecture, complex logic stays in the Repository.
            var result = await _studentService.GetStudentsWithCoursesAsync();
            return Ok(result);
        }
    }
}