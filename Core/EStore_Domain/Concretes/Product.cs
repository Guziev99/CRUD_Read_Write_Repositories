using EStore_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Domain.Concretes
{
    public  class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stoke { get; set;}
        public string? ImageUrl { get; set;}


        // Foreign Key
        public int? CategoryId { get; set; }
        //public int? OrderId { get; set; }


        // Navigation Properties


        // JsonIgnore
        public virtual Category? Category { get; set; }
        //public virtual Order? Order { get; set; }

    }
}
