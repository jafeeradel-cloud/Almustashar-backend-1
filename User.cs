using System.ComponentModel.DataAnnotations;

namespace RealEstateApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? OfficeName { get; set; }   // ✅ هذا السطر المهم

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
