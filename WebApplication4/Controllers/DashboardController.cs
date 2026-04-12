using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
  
    private readonly IStudentService _studentService;
    private readonly ICourseService _courseService;
   
    private readonly IModuleRepository _moduleRepo;
    private readonly IEnrollmentService _enrollmentService;
    private readonly IInstructorService _instructorService;

    public DashboardController(
        IStudentService studentService,
        ICourseService courseService,
        IModuleRepository moduleRepo,
        IEnrollmentService enrollmentService,
        IInstructorService instructorService)
    {
        _studentService = studentService;
        _courseService = courseService;
        _moduleRepo = moduleRepo;
        _enrollmentService = enrollmentService;
        _instructorService = instructorService;
    }

    [HttpGet("summary")]
    public async Task<ActionResult<object>> GetSummary()
    {
     
        var students = await _studentService.GetAllStudentsAsync();
        var courses = await _courseService.GetAllAsync();
        var modules = await _moduleRepo.GetAllAsync();
        var enrollments = await _enrollmentService.GetAllAsync();
        var instructors = await _instructorService.GetAllAsync();

        return Ok(new
        {
            totalStudents = students.Count(),
            totalCourses = courses.Count(),
            totalModules = modules.Count(),
            totalEnrollments = enrollments.Count(),
            totalInstructors = instructors.Count()
        });
    }
}