using EStore_Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Repositories.Common
{
    public interface IWriteGenericRepository <T> : IGenericRepository<T> where T : class, IBaseEntity, new()
    {
        Task AddAsync (T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(int id);
        Task DeleteAsync (T entity);
        Task UpdateAsync(T entity);
        Task SaveChangeAsync();


        



        
    }
}
