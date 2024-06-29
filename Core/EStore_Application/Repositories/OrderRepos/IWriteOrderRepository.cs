using EStore_Application.Repositories.Common;
using EStore_Domain.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Repositories.OrderRepos
{
    public interface IWriteOrderRepository : IWriteGenericRepository <Order>
    {
    }
}
