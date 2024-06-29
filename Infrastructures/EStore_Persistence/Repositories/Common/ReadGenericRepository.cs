using EStore_Application.Repositories.Common;
using EStore_Domain.Abstracts;
using EStore_Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Repositories.Common
{
    public class ReadGenericRepository<T> : GenericRepository<T>, IReadGenericRepository<T> where T : class, IBaseEntity, new()
    {

         
        public ReadGenericRepository(EStore_DbContext context) : base(context){   }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _table;
        }

        public async Task<IQueryable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
