using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AIPO74_HFT_2021221.Models
{
  public  class ContextTable : DbContext
    {
        public ContextTable()
        {
            this.Database.EnsureCreated();
        }
        public ContextTable(DbContextOptions<ContextTable> options) : base(options)
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LaboratoryStaff> Staffs { get; set; }

        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<LaboratoryOrders> Orders { get; set; }

        public virtual DbSet<ConnectionTable> Connections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null && !optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; Attachdbfilename=|DataDirectory|\Database1.mdf; Integrated security=True; MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Services services1 = new Services() { Id = 1, Name = "Biological Weapon", Price = 80000, Dangerous = 8 };
            Services services2 = new Services() { Id = 2, Name = "Biological Weapon", Price = 80000, Dangerous = 8 };
            Services services3 = new Services() { Id = 3, Name = "Biological Weapon", Price = 80000, Dangerous = 8 };
            Services services4 = new Services() { Id = 4, Name = "Biological Weapon", Price = 80000, Dangerous = 8 };
            Services services5 = new Services() { Id = 5, Name = "Biological Weapon", Price = 80000, Dangerous = 8 };
        }
    }
}
