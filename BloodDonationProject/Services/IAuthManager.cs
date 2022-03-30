using BloodDonationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationProject.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginAccountDTO accountDTO);
        Task<string> CreateToken();
    }
}
