using EStore_Application.Repositories.ProductRepos;
using EStore_Domain.Concretes;
using EStore_Persistence.DBContexts;
using EStore_Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Repositories.ProductRepo
{
    public class WriteProductRepository : WriteGenericRepository<Product>, IWriteProductRepository
    {
        public WriteProductRepository(EStore_DbContext context) : base(context)
        {
        }
    }
}
