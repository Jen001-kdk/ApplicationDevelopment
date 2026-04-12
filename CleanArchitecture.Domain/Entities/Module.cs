using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;

    public class Module
    {
        public int Id { get; set; }
        public string Title     { get; set; }
        public double Credits { get; set; }

        [ForeignKey(nameof(CourseId))]
        public int CourseId { get; set; }
        public Course Course { get; set; }

       
    }






   
