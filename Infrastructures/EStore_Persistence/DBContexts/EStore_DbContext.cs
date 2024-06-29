using EStore_Domain.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.DBContexts
{
    public  class EStore_DbContext : DbContext
    {
        public EStore_DbContext(DbContextOptions<EStore_DbContext> options) : base(options) { }


        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
