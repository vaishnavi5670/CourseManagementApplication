using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.DTOs
{
    public class StudentDto
    {
        public int StudentId { get; set; }


        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;


        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;


        [Phone]
        public string? Phone { get; set; }


        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
    }
}
