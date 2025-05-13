using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.ZhangS.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string? Make { get; set; }

        [Required, StringLength(50)]
        public string? Model { get; set; }

        [Required, Range(1990, 2050)]
        public int Year { get; set; }

        [StringLength(20)]
        public string? Color { get; set; }

        // Navigation property
        public ICollection<ServiceBooking>? ServiceBookings { get; set; }
    }
}
