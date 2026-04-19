using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepo;

        public EnrollmentsController(IEnrollmentRepository enrollmentRepo)
        {
            _enrollmentRepo = enrollmentRepo;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollments()
            => Ok(await _enrollmentRepo.GetAllAsync());

        [HttpPost]
        public async Task<ActionResult<Enrollment>> PostEnrollment(Enrollment enrollment)
        {
           
            var existing = await _enrollmentRepo.GetAllAsync();
            var isAlreadyEnrolled = existing.Any(e =>
                e.StudentId == enrollment.StudentId &&
                e.CourseId == enrollment.CourseId);

            if (isAlreadyEnrolled)
            {
                return BadRequest(new { message = "Student is already enrolled in this course." });
            }

            await _enrollmentRepo.AddAsync(enrollment);
            return Ok(enrollment);
        }

        
        [HttpGet("full-details")]
        public async Task<ActionResult<IEnumerable<object>>> GetFullDetails()
            => Ok(await _enrollmentRepo.GetEnrollmentDetailsAsync());

      
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetEnrollmentCount()
        {
            var list = await _enrollmentRepo.GetAllAsync();
            return Ok(list.Count());
        }

       
        [HttpGet("my-courses/{studentId}")]
        public async Task<ActionResult> GetMyCourses(string studentId)
        {
            var allEnrollments = await _enrollmentRepo.GetAllAsync();
            var myEnrollments = allEnrollments.Where(e => e.StudentId.ToString() == studentId);
            return Ok(myEnrollments);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            await _enrollmentRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}

