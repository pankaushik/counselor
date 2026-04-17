using System;
using System.ComponentModel.DataAnnotations;

namespace Counselor.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string? Phone { get; set; }

        [Required]
        public string Service { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}