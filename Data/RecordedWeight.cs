using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WeightRecorder.Data
{
    public class RecordedWeight
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Weight { get; set; }

        public string UserId { get; set; }

        [Required]
        public IdentityUser User { get; set; }
    }
}
