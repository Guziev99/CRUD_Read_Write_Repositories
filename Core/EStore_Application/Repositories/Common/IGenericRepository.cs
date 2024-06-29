using EStore_Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Repositories.Common
{
    public interface IGenericRepository <T> where T : class, IBaseEntity, new()
    {
        
        
    }
}
