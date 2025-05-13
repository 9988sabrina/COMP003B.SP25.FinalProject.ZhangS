using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.ZhangS.Models
{
    public class ServiceBooking
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int MechanicId { get; set; }

        [Required]
        public int ServiceTypeId { get; set; }

        [Required]
        public DateTime ServiceDate { get; set; }

        [Range(0, 5000)]
        public decimal Cost { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        // Navigation properties
        public Car? Car { get; set; }
        public Customer? Customer { get; set; }
        public Mechanic? Mechanic { get; set; }
        public ServiceType? ServiceType { get; set; }
    }
}
