using EStore_Application.Repositories.Common;
using EStore_Domain.Abstracts;
using EStore_Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Repositories.Common
{
    public class WriteGenericRepository<T> : GenericRepository<T>, IWriteGenericRepository<T> where T : class, IBaseEntity, new()
    {
        public WriteGenericRepository(EStore_DbContext context) : base(context)
        {
        }

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync  (entities);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _table.FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null)
             _table.Remove(entity);
        }

        public async Task DeleteAsync(T entity)
        {
              _table.Remove(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _table.Update(entity);
        }


        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
