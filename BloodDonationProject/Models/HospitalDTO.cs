using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationProject.Models
{
    public class CreateHospitalDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
    }
    public class HospitalDTO : CreateHospitalDTO
    {
        public int Id { get; set; }
        public virtual IList<DonationDTO> Donations { get; set; }
    }
}
