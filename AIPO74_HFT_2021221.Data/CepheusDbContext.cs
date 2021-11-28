using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;

namespace AIPO74_HFT_2021221.Data
{
    public class CepheusDbContext : DbContext
    { 
        public CepheusDbContext()
        {
            this.Database.EnsureCreated();
        }
        public CepheusDbContext(DbContextOptions<CepheusDbContext> options) : base(options)
        {
            this.Database?.EnsureCreated();
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LaboratoryStaff> Staffs { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<LaboratoryOrders> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null && !optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database1.mdf; Integrated security=True; MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Services> servicesList = new List<Services>
            {
                new Services{ServiceId = 1, Name = "Biological Weapon", Price = 80000, Dangerous = 8, DevelopmentTime = 6 },
                new Services { ServiceId = 2, Name = "New Bacteria", Price = 20000, Dangerous = 2, DevelopmentTime = 5 },
                new Services { ServiceId = 3, Name = "Virus weapom", Price = 900000, Dangerous = 10, DevelopmentTime = 4 },
                new Services { ServiceId = 4, Name = "A cure of Cancer", Price = 100000, Dangerous = 3, DevelopmentTime = 3 },
                new Services { ServiceId = 5, Name = "Plasma Weapon", Price = 8000, Dangerous = 2, DevelopmentTime = 5 }
            };


            List<LaboratoryStaff> laboratoryStaffsList = new List<LaboratoryStaff>
            {
            new LaboratoryStaff { StaffID = 1, FullName = "Bertami Loker", Position = "Microbiologist", AccessLevel = "A", YearExpirience = 5 },
            new LaboratoryStaff { StaffID = 2, FullName = "Melisa Hlou", Position = "Virologist", AccessLevel = "B", YearExpirience = 2 },
            new LaboratoryStaff { StaffID = 3, FullName = "Anton Volkov", Position = "Technician specialist", AccessLevel = "C", YearExpirience = 3 },
            new LaboratoryStaff { StaffID = 4, FullName = "Gustav Claus", Position = "Bacteriologist", AccessLevel = "D", YearExpirience = 5 },
            new LaboratoryStaff { StaffID = 5, FullName = "Linda Vagh", Position = "Virologist", AccessLevel = "B", YearExpirience = 4 } 
            };

            List<Customer> customersList = new List<Customer> 
            {
            new Customer { CustomerID = 1, Name = "Poll Woker", Phone = "+17(214)37-41-42", Address = "45 Creekside Ave", City = "Los-Angeles", Country = "USA", SecrecyStamp = "Medium level" },
            new Customer { CustomerID = 2, Name = "Jeremi Matos", Phone = "+3(630)187-42-60", Address = "97 Helen St.", City = "Budapest", Country = "Hungary", SecrecyStamp = "Low level" },
            new Customer { CustomerID = 3, Name = "Viktor Reznov", Phone = "+7(964)254-63-63", Address = "Stalin St. 17", City = "Moscow", Country = "Russia", SecrecyStamp = "Top secret" },
            new Customer { CustomerID = 4, Name = "Price Jon", Phone = "+1(789)-458-696", Address = "77 San Carlos Drive", City = "New Mexico", Country = "Mexica", SecrecyStamp = "Hight level" },
            new Customer { CustomerID = 5, Name = "Ben-Laden", Phone = "+2(548)216-464", Address = "5 Acacia Street", City = "Bagdad", Country = "Afganistan", SecrecyStamp = "Top secret" }
            };


            List<LaboratoryOrders> laboratoryOrdersList = new List<LaboratoryOrders> 
            {
                new LaboratoryOrders { Id = 1, Date = new DateTime(2007, 06, 17), CustomerID = customersList[0].CustomerID, StaffID = laboratoryStaffsList[0].StaffID, ServiceId = servicesList[0].ServiceId },
                new LaboratoryOrders { Id = 2, Date = new DateTime(2008, 04, 14), CustomerID = customersList[0].CustomerID, StaffID = laboratoryStaffsList[1].StaffID, ServiceId = servicesList[1].ServiceId },
                new LaboratoryOrders { Id = 3, Date = new DateTime(2017, 06, 12), CustomerID = customersList[1].CustomerID, StaffID = laboratoryStaffsList[2].StaffID, ServiceId = servicesList[2].ServiceId },
                new LaboratoryOrders { Id = 4, Date = new DateTime(2012, 06, 26), CustomerID = customersList[2].CustomerID, StaffID = laboratoryStaffsList[3].StaffID, ServiceId = servicesList[3].ServiceId },
                new LaboratoryOrders { Id = 5, Date = new DateTime(2013, 07, 21), CustomerID = customersList[4].CustomerID, StaffID = laboratoryStaffsList[4].StaffID, ServiceId = servicesList[4].ServiceId },
               
               
            };
  
            
            modelBuilder.Entity<Customer>().HasData(customersList);
            modelBuilder.Entity<LaboratoryStaff>().HasData(laboratoryStaffsList);
            modelBuilder.Entity<Services>().HasData(servicesList);
            modelBuilder.Entity<LaboratoryOrders>().HasData(laboratoryOrdersList);


        }






    }
}
