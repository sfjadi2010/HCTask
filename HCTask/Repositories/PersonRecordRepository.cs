using HCTask.Models;
using HCTask.PersonContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCTask.Repositories
{
    public class PersonRecordRepository : IRepositoryBase<PersonRecord>
    {
        private readonly PersonDbContext _context;

        public PersonRecordRepository(PersonDbContext context)
        {
            _context = context;
        }

        public async Task<PersonRecord> CreateAsync(PersonRecord entity)
        {
            _context.People.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(PersonRecord entity)
        {
            _context.People.Remove(entity);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<IEnumerable<PersonRecord>> FindAllAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<PersonRecord> FindByIdAsync(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task<IEnumerable<PersonRecord>> SearchAsync(string searchText)
        {
            return await _context.People.Where<PersonRecord>(
                p => p.FirstName.ToLower().Contains(searchText) ||
                p.LastName.ToLower().Contains(searchText)).ToListAsync();
        }

        public async Task<PersonRecord> UpdateAsync(PersonRecord entity)
        {
            throw new NotImplementedException();
        }
    }
}
