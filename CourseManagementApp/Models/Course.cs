using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }


        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;


        [StringLength(100000)]
        public string? Description { get; set; }


        [Range(0, 10000)]
        public decimal Fee { get; set; }


        [Required]
        public bool IsActive { get; set; } = true;


        // navigation
        public ICollection<StudentEnrollment>? StudentEnrollment { get; set; }
    }
}
