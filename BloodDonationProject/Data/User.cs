using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationProject.Data
{
    public class User
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        public IList<Donation> Donations { get; set; }
    }
}
