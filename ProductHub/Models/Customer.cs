using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Customer
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(15)]
        public string? Phone { get; set; }
    }
}
