using EStore_Application.Repositories.OrderRepos;
using EStore_Domain.Concretes;
using EStore_Persistence.DBContexts;
using EStore_Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Repositories.OrderRepo
{
    public class ReadOrderRepository : ReadGenericRepository<Order>, IReadOrderRepository
    {
        public ReadOrderRepository(EStore_DbContext context) : base(context)
        {
        }
    }
}
