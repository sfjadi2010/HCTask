using HCTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCTask.Repositories
{
    public class PersonRecordRepository : IRepositoryBase<PersonRecord>
    {
        public async Task<PersonRecord> CreateAsync(PersonRecord entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(PersonRecord entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonRecord>> FindAllAsync()
        {
            throw new NotImplementedException();
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
