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
            Services services2 = new Services() { Id = 2, Name = "New Bacteria", Price = 20000, Dangerous = 2 };
            Services services3 = new Services() { Id = 3, Name = "Virus weapom", Price = 900000, Dangerous = 10 };
            Services services4 = new Services() { Id = 4, Name = "A cure of Cancer", Price = 100000, Dangerous = 3 };
            Services services5 = new Services() { Id = 5, Name = "Plasma Weapon", Price = 8000, Dangerous = 2 };

            LaboratoryStaff staff1 = new LaboratoryStaff() { Id = 1, FullName = "Bertami Loker", Position = "Microbiologist", AccessLevel = "A", YearExpirience = 5};
            LaboratoryStaff staff2 = new LaboratoryStaff() { Id = 2, FullName = "Melisa Hlou", Position = "Virologist", AccessLevel = "B", YearExpirience = 2};
            LaboratoryStaff staff3 = new LaboratoryStaff() { Id = 3, FullName = "Anton Volkov", Position = "Technician specialist", AccessLevel = "C", YearExpirience = 3};
            LaboratoryStaff staff4 = new LaboratoryStaff() { Id = 4, FullName = "Gustav Claus", Position = "Bacteriologist", AccessLevel = "D", YearExpirience = 5};
            LaboratoryStaff staff5 = new LaboratoryStaff() { Id = 5, FullName = "Linda Vagh", Position = "Virologist", AccessLevel = "B", YearExpirience = 4};

            Customer customer1 = new Customer() { Id = 1, Name = "Poll Woker", Phone = "+17(214)37-41-42", Address = "", City = "", Country = "", SecrecyStamp = ""};
            Customer customer2 = new Customer() { Id = 1, Name = "Jeremi Matos", Phone = "+3(630)187-42-60", Address = "", City = "", Country = "", SecrecyStamp = ""};
            Customer customer3 = new Customer() { Id = 1, Name = "Viktor Reznov", Phone = "+7(964)254-63-63", Address = "", City = "", Country = "", SecrecyStamp = ""};
            Customer customer4 = new Customer() { Id = 1, Name = "Price Jon", Phone = "+1(789)-458-696", Address = "", City = "", Country = "", SecrecyStamp = ""};
            Customer customer5 = new Customer() { Id = 1, Name = "Ben-Laden", Phone = "+2(548)216-464", Address = "", City = "", Country = "", SecrecyStamp = ""};

        }
    }
}
