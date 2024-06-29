using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Domain.ViewModels
{
    public  class ProductVM
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stoke { get; set; }
        

        public int CategoryId { get; set; }
    }
}
