using BloodDonationProject.Data;
using BloodDonationProject.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<User> _users;
        private IGenericRepository<Hospital> _hospitals;
        private IGenericRepository<Donation> _donations;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);

        public IGenericRepository<Hospital> Hospitals => _hospitals ??= new GenericRepository<Hospital>(_context);

        public IGenericRepository<Donation> Donations => _donations ??= new GenericRepository<Donation>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
