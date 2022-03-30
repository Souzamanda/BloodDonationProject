using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationProject.Models
{
    public class CreateUserDTO
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string sex { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        public string phone { get; set; }

        [Required]
        public string address { get; set; }
    }

    public class UpdateUserDTO : CreateUserDTO
    {

    }

    public class UserDTO : CreateUserDTO
    {
        public int Id { get; set; }
        public virtual IList<DonationDTO> Donations { get; set; }
    }
}
