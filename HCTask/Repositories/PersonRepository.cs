using HCTask.Models;
using HCTask.PersonContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCTask.Repositories
{
    public class PersonRepository : IRepositoryBase<Person>
    {
        private readonly PersonDbContext _context;

        public PersonRepository(PersonDbContext context)
        {
            _context = context;
        }

        public async Task<Person> CreateAsync(Person entity)
        {
            _context.People.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Person entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> FindByIdAsync(int Id)
        {
            return await new List<Person>();
        }

        public IEnumerable<Person> SearchAsync(string searchText)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> UpdateAsync(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
