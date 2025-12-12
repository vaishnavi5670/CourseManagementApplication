using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.DTOs
{
    public class AdminDto
    {
        public int AdminId { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [Phone]
        public string? Phone { get; set; }
    }
}
