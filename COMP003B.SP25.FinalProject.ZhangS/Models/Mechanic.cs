using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.ZhangS.Models
{
    public class Mechanic
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string? FullName { get; set; }

        [Required, StringLength(100)]
        public string? Specialization { get; set; }

        [Required, StringLength(20)]
        public string? PhoneNumber { get; set; }

        [Required, StringLength(100)]
        public string? CertificationNumber { get; set; }

        [Range(1, 50)]
        public int ExperienceYears { get; set; }

        public ICollection<ServiceBooking>? ServiceBookings { get; set; }
    }
}
