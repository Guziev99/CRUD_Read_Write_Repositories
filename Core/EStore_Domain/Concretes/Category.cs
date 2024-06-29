using EStore_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Domain.Concretes
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string ? ImageUrl { get; set; }


        // Navigation Property
        public virtual ICollection<Product>? Products { get; set;}
    }
}
