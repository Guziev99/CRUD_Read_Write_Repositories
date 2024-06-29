using EStore_Application.Repositories.CategoryRepos;
using EStore_Domain.Concretes;
using EStore_Persistence.DBContexts;
using EStore_Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Repositories.CategoryRepo
{
    public class ReadCategoryRepository : ReadGenericRepository<Category>, IReadCategoryRepository
    {
        public ReadCategoryRepository(EStore_DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsWithCategoryId(int categoryid)
        {
            var products = _table.Include(c => c.Products).FirstOrDefault(c => c.Id == categoryid)?.Products;

            return products;
        }
    }
}
