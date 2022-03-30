using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationProject.Models
{
    public class LoginAccountDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 5)]
        public string Password { get; set; }
    }

    public class AccountDTO : LoginAccountDTO
    {
        public string FirstName { get; set; }
        public ICollection<string> Roles { get; set; }
    }

}
