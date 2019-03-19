using HCTask.Models;
using HCTask.PersonContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCTask.Repositories
{
    public class AddressRepository : IRepositoryBase<Address>
    {
        private readonly PersonDbContext _context;
        public AddressRepository(PersonDbContext context)
        {
            _context = context;
        }

        public Task<Address> CreateAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Address> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> SearchAsync(string searchText)
        {
            throw new NotImplementedException();
        }

        public Task<Address> UpdateAsync(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
