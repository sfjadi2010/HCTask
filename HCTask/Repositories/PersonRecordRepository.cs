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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonRecord>> FindAllAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<PersonRecord> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonRecord>> SearchAsync(string searchText)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonRecord> UpdateAsync(PersonRecord entity)
        {
            throw new NotImplementedException();
        }
    }
}
