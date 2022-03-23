using BloodDonationProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationProject.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Hospital> Hospitals { get; }
        IGenericRepository<Donation> Donations { get; }

        Task Save();
    }
}
