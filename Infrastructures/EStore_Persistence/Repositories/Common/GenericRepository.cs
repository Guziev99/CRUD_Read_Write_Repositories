using EStore_Application.Repositories.Common;
using EStore_Domain.Abstracts;
using EStore_Domain.Common;
using EStore_Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Repositories.Common
{
    public class GenericRepository <T> : IGenericRepository<T> where T : class, IBaseEntity, new()  
    {
        protected readonly EStore_DbContext _context;
        protected DbSet<T> _table;
        public GenericRepository(EStore_DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();                          
        }
    }
}
