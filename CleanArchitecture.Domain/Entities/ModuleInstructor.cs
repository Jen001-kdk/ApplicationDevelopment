using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities
{
    public class ModuleInstructor
    {
        public int Id { get; set; }
        [ForeignKey(nameof(ModuleId))]
        public int ModuleId { get; set; }
        public Module Module { get; set; }

        [ForeignKey(nameof(InstructorId))]

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
