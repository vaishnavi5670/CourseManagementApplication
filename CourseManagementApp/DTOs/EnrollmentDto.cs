using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.DTOs
{
    public class EnrollmentDto
    {
        public int EnrollmentId { get; set; }


        [Required]
        public int StudentId { get; set; }


        [Required]
        public int CourseId { get; set; }


        [DataType(DataType.Date)]
        public DateTime EnrolledOn { get; set; } = DateTime.UtcNow;


        [StringLength(50)]
        public string? Status { get; set; }


        [Range(0, 100)]
        public int? Grade { get; set; }
    }
}
