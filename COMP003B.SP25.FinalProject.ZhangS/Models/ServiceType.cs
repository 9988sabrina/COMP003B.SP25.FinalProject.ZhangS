using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.ZhangS.Models
{
    public class ServiceType
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string? Name { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [Range(50, 5000)]
        public decimal Cost { get; set; }

        [Range(0.5, 24)]
        public double DurationEstimate { get; set; }

        [StringLength(200)]
        public string? Notes { get; set; }

        public ICollection<ServiceBooking>? ServiceBookings { get; set; }
    }
}
