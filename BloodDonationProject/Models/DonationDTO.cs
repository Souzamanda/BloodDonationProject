using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationProject.Models
{
    public class CreateDonationDTO
    {
        [Required]
        [StringLength(maximumLength: 3, MinimumLength = 2, ErrorMessage = "Enter correct blood type")]
        public string BloodType { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int HospitalId { get; set; }
    }

    public class UpdateDonationDTO : CreateDonationDTO
    {

    }

    public class DonationDTO : CreateDonationDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public HospitalDTO Hospital { get; set; }
    }
}
