using EStore_Application.Repositories.CategoryRepos;
using EStore_Domain.Concretes;
using EStore_Persistence.DBContexts;
using EStore_Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Repositories.CategoryRepo
{
    public class WriteCategoyrRepository : WriteGenericRepository<Category>, IWriteCategoryRepository
    {
        public WriteCategoyrRepository(EStore_DbContext context) : base(context)
        {
        }
    }
}
