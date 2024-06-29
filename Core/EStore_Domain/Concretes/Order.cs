using EStore_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Domain.Concretes
{
    public class Order : BaseEntity
    {
        public string ? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? OrderNote { get; set; }
        public decimal? TotalPrice { get; set; }


        // Foreign Key
        public int? CustomerId { get; set; }


        // Navigation Properties
        public virtual ICollection<Product>? Products { get; set; }
        public virtual Customer?  Customer { get; set; }

    }
}
