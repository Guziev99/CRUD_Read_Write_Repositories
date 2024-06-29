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
    public class WriteCustomerRepository : WriteGenericRepository<Customer>, IWriteCustomerRepository
    {
        public WriteCustomerRepository(EStore_DbContext context) : base(context)
        {
        }
    }
}
