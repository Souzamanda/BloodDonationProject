using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationProject.Data
{
    public class Donation
    {
        public int Id { get; set; }
        public string BloodType { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Hospital))]
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}
