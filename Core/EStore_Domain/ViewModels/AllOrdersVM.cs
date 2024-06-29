using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Domain.ViewModels
{
    public class AllOrdersVM
    {
        public string? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? OrderNote { get; set; }
        public decimal? TotalPrice { get; set; }


        // Foreign Key
        public int? CustomerId { get; set; }
    }
}
