using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }

