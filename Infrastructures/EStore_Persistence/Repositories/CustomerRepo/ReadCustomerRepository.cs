using EStore_Application.Repositories.CustomerRepos;
using EStore_Domain.Concretes;
using EStore_Persistence.DBContexts;
using EStore_Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Repositories.CustomerRepo
{
    public class ReadCustomerRepository : ReadGenericRepository<Customer>, ICustomerReadRepository
    {
        public ReadCustomerRepository(EStore_DbContext context) : base(context)
        {
        }
    }
}
