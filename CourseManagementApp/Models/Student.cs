using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100)]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Full Name must contain only letters and spaces.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^91\d{10}$", ErrorMessage = "Phone must start with 91 and contain 12 digits.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        // Navigation property
        public ICollection<StudentEnrollment>? StudentEnrollments { get; set; }
    }
}
