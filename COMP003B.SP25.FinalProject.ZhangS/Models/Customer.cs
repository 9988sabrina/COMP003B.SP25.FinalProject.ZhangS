using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.ZhangS.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string? FullName { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required, StringLength(20)]
        public string? PhoneNumber { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [Range(0, 10000)]
        public int LoyaltyPoints { get; set; }

        public ICollection<ServiceBooking>? ServiceBookings { get; set; }
    }
}
