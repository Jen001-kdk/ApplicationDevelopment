using System.ComponentModel.DataAnnotations;




namespace CleanArchitecture.Domain.Entities;

    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public int DurationYears { get; set; }

        public ICollection<Module> Modules { get; set; } = new List<Module>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }


