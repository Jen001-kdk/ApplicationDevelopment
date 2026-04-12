using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(StudentId))]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey(nameof (CourseId))]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime EnrolledDate { get; set; }
        
    }
}
