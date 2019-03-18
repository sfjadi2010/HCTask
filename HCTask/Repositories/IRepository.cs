using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCTask.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindByIdAsync(int Id);
        Task<IEnumerable<T>> SearchAsync(string searchText);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
