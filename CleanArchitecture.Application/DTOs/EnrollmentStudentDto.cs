namespace CleanArchitecture.Application.DTOs;

public class EnrollStudentDto
{
    public string StudentId { get; set; } = string.Empty; 
    public int CourseId { get; set; }
}