using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Models
{
    public class StudentEnrollment
    {
        [Key]
        public int EnrollmentId { get; set; }


        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }


        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }


        [DataType(DataType.Date)]
        public DateTime EnrolledOn { get; set; } = DateTime.UtcNow;


        [StringLength(50)]
        public string? Status { get; set; } = "Enrolled"; // Enrolled, Completed, Cancelled


        [Range(0, 100)]
        public int? Grade { get; set; }
    }
}
