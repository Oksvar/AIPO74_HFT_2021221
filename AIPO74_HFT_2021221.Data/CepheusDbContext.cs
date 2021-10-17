using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;

namespace AIPO74_HFT_2021221.Data
{
     public  class CepheusDbContext : DbContext
    {
        public CepheusDbContext()
        {
            this.Database.EnsureCreated();
        }
        public CepheusDbContext(DbContextOptions<CepheusDbContext> options) : base(options)
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

            LaboratoryStaff staff1 = new LaboratoryStaff() { Id = 1, FullName = "Bertami Loker", Position = "Microbiologist", AccessLevel = "A", YearExpirience = 5 };
            LaboratoryStaff staff2 = new LaboratoryStaff() { Id = 2, FullName = "Melisa Hlou", Position = "Virologist", AccessLevel = "B", YearExpirience = 2 };
            LaboratoryStaff staff3 = new LaboratoryStaff() { Id = 3, FullName = "Anton Volkov", Position = "Technician specialist", AccessLevel = "C", YearExpirience = 3 };
            LaboratoryStaff staff4 = new LaboratoryStaff() { Id = 4, FullName = "Gustav Claus", Position = "Bacteriologist", AccessLevel = "D", YearExpirience = 5 };
            LaboratoryStaff staff5 = new LaboratoryStaff() { Id = 5, FullName = "Linda Vagh", Position = "Virologist", AccessLevel = "B", YearExpirience = 4 };

            Customer customer1 = new Customer() { Id = 1, Name = "Poll Woker", Phone = "+17(214)37-41-42", Address = "45 Creekside Ave", City = "Los-Angeles", Country = "USA", SecrecyStamp = "Medium level" };
            Customer customer2 = new Customer() { Id = 2, Name = "Jeremi Matos", Phone = "+3(630)187-42-60", Address = "97 Helen St.", City = "Budapest", Country = "Hungary", SecrecyStamp = "Low level" };
            Customer customer3 = new Customer() { Id = 3, Name = "Viktor Reznov", Phone = "+7(964)254-63-63", Address = "Stalin St. 17", City = "Moscow", Country = "Russia", SecrecyStamp = "Top secret" };
            Customer customer4 = new Customer() { Id = 4, Name = "Price Jon", Phone = "+1(789)-458-696", Address = "77 San Carlos Drive", City = "New Mexico", Country = "Mexica", SecrecyStamp = "Hight level" };
            Customer customer5 = new Customer() { Id = 5, Name = "Ben-Laden", Phone = "+2(548)216-464", Address = "5 Acacia Street", City = "Bagdad", Country = "Afganistan", SecrecyStamp = "Top secret" };

            LaboratoryOrders orders1 = new LaboratoryOrders() { Id = 1, CustomerID = customer1.Id, ScientistID = staff2.Id, DateTime = new DateTime(2007, 06, 17) };
            LaboratoryOrders orders2 = new LaboratoryOrders() { Id = 2, CustomerID = customer3.Id, ScientistID = staff1.Id, DateTime = new DateTime(2010, 07, 17) };
            LaboratoryOrders orders3 = new LaboratoryOrders() { Id = 3, CustomerID = customer2.Id, ScientistID = staff3.Id, DateTime = new DateTime(2020, 12, 17) };
            LaboratoryOrders orders4 = new LaboratoryOrders() { Id = 4, CustomerID = customer5.Id, ScientistID = staff4.Id, DateTime = new DateTime(2003, 11, 17) };
            LaboratoryOrders orders5 = new LaboratoryOrders() { Id = 5, CustomerID = customer4.Id, ScientistID = staff5.Id, DateTime = new DateTime(2006, 09, 17) };

            ConnectionTable connection1 = new ConnectionTable() { Id = 1, OrderID = orders1.Id, ServeceID = services2.Id };
            ConnectionTable connection2 = new ConnectionTable() { Id = 2, OrderID = orders2.Id, ServeceID = services3.Id };
            ConnectionTable connection3 = new ConnectionTable() { Id = 3, OrderID = orders3.Id, ServeceID = services4.Id };
            ConnectionTable connection4 = new ConnectionTable() { Id = 4, OrderID = orders5.Id, ServeceID = services1.Id };
            ConnectionTable connection5 = new ConnectionTable() { Id = 5, OrderID = orders4.Id, ServeceID = services2.Id };


            modelBuilder.Entity<LaboratoryOrders>(entity =>
            {
                      entity.HasOne(LaboratoryOrders => LaboratoryOrders.Scientists)
                        .WithMany(scientists => scientists.Orders)
                     .HasForeignKey(LaboratoryOrders => LaboratoryOrders.ScientistID)
                        .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<LaboratoryOrders>(entity =>
            {
                entity.HasOne(LaboratoryOrders => LaboratoryOrders.Customers)
                  .WithMany(scientists => scientists.Orders)
               .HasForeignKey(LaboratoryOrders => LaboratoryOrders.CustomerID)
                  .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ConnectionTable>(entity =>
            {
                entity.HasOne(connection => connection.Orders)
                  .WithMany(orders => orders.ConnectionTables)
               .HasForeignKey(connection => connection.OrderID)
                  .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ConnectionTable>(entity =>
            {
                entity.HasOne(connection => connection.Services)
                  .WithMany(service => service.ConnectionTables)
               .HasForeignKey(connection => connection.ServeceID)
                  .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Customer>().HasData(customer1, customer2, customer3, customer4, customer5);
            modelBuilder.Entity<LaboratoryStaff>().HasData(staff1, staff2, staff3, staff4, staff5);
            modelBuilder.Entity<Services>().HasData(services1, services2,services3,services4,services5);
            modelBuilder.Entity<LaboratoryOrders>().HasData(orders1, orders2, orders3, orders4, orders5);
            modelBuilder.Entity<ConnectionTable>().HasData(connection1, connection2, connection3, connection4, connection5);



        }
    }
}
