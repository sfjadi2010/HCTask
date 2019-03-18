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

        public Address Create(Address entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Address entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Save(Address entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public Address Update(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
