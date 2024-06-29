using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Domain.ViewModels
{
    public  record PaginationVM
    {
        public int Page { get; init; } = 0;
        public int PageSize { get; init; } = 5;
    }
}
