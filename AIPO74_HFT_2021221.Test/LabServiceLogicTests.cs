using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Models;
using AIPO74_HFT_2021221.Logic;
using AIPO74_HFT_2021221.Repository;
using Moq;
using AIPO74_HFT_2021221.Data;
using Microsoft.EntityFrameworkCore;

namespace AIPO74_HFT_2021221.Test
{
    [TestFixture]
    public class LabServiceLogicTests
    {
        IServices servicesRepo;
        ILaboratoryStaffRepo staffRepo;
        ILaboratoryOrderRepo orderRepo;
        ICustomerRepo customerRepo;

        LaboratoryStaffLogic staffLogic;
        CustomerLogic CustomerLogic;
        ServiceLogic serviceLogic;
        LaboratoryOrderLogic orderLogic;

        #region CRUD
        [Test]
        public void GetServiceId()
        {
            serviceLogic.GetServicesID(1);

        }
        [Test]
        public void GetOrderID()
        {
            var ord = orderLogic.GetLaboratoryOrders();
            Assert.That(orderLogic.GetLaboratoryOrders().Count() > 0, Is.True);

        }
        [Test]
        public void CreateCustomer()
        {
            Customer customer = new Customer
            {
                CustomerID = 1,
                Address = "Test adress",
                City = "test4",
                Country = "test3",
                Name = "Andreas",
                Phone = "Test2",
                SecrecyStamp = "test1"

            };
            Assert.That(() => CustomerLogic.CreateCustomer(customer), Throws.InvalidOperationException);

        }

        [Test]
        public void GetOneStaff()
        {
            var got = staffLogic.GetStaffID(1);
            Assert.That(got.FullName == ("Bertami Loker"));
        }

        [Test]
        public void CreateService()
        {
            Services services = new Services
            {
                ServiceId = 1,
                Name = "Test Service",
                Price = 80000,
                Dangerous = 9,
                DevelopmentTime = 632
            };
            Assert.That(() => serviceLogic.CreateService(services), Throws.InvalidOperationException);

        }
        #endregion

        #region non-crud

        #endregion







        [SetUp]
        public void Setup()
        {
            List<Services> servicesList = new List<Services>
            {
                new Services {  ServiceId = 1, Name = "Biological Weapon", Price = 80000, Dangerous = 8, DevelopmentTime = 6 },
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

            Mock<CepheusDbContext> contextMock = new Mock<CepheusDbContext>();

            Mock<DbSet<Services>> ServicesDbSetMock = new Mock<DbSet<Services>>();
            Mock<DbSet<LaboratoryStaff>> LaboratoryStaffDbSetMock = new Mock<DbSet<LaboratoryStaff>>();
            Mock<DbSet<Customer>> CustomerDbSetMock = new Mock<DbSet<Customer>>();
            Mock<DbSet<LaboratoryOrders>> LaboratoryOrdersDbSetMock = new Mock<DbSet<LaboratoryOrders>>();

            servicesRepo = new ServicesRepo(contextMock.Object);
            staffRepo = new LaboratoryStaffRepo(contextMock.Object);
            orderRepo = new LaboratoryOrderRepo(contextMock.Object);
            customerRepo = new CustomerRepo(contextMock.Object);

            IQueryable<Services> ServicesQuery = servicesList.AsQueryable();
            IQueryable<LaboratoryStaff> LaboratoryStaffQuery = laboratoryStaffsList.AsQueryable();
            IQueryable<Customer> CustomerQuery = customersList.AsQueryable();
            IQueryable<LaboratoryOrders> LaboratoryOrdersQuery = laboratoryOrdersList.AsQueryable();


            ServicesDbSetMock.As<IQueryable<Services>>()
                .Setup(mock => mock.Provider)
                .Returns(ServicesQuery.Provider);

            ServicesDbSetMock.As<IQueryable<Services>>()
                .Setup(mock => mock.Expression)
                .Returns(ServicesQuery.Expression);

            ServicesDbSetMock.As<IQueryable<Services>>()
                .Setup(mock => mock.ElementType)
                .Returns(ServicesQuery.ElementType);

            ServicesDbSetMock.As<IQueryable<Services>>()
                .Setup(mock => mock.GetEnumerator())
                .Returns(ServicesQuery.GetEnumerator());


            LaboratoryStaffDbSetMock.As<IQueryable<LaboratoryStaff>>()
                .Setup(mock => mock.Provider)
                .Returns(LaboratoryStaffQuery.Provider);

            LaboratoryStaffDbSetMock.As<IQueryable<LaboratoryStaff>>()
                .Setup(mock => mock.Expression)
                .Returns(LaboratoryStaffQuery.Expression);

            LaboratoryStaffDbSetMock.As<IQueryable<LaboratoryStaff>>()
                .Setup(mock => mock.ElementType)
                .Returns(LaboratoryStaffQuery.ElementType);

            LaboratoryStaffDbSetMock.As<IQueryable<LaboratoryStaff>>()
                .Setup(mock => mock.GetEnumerator())
                .Returns(LaboratoryStaffQuery.GetEnumerator());


            CustomerDbSetMock.As<IQueryable<Customer>>()
                .Setup(mock => mock.Provider)
                .Returns(CustomerQuery.Provider);

            CustomerDbSetMock.As<IQueryable<Customer>>()
                .Setup(mock => mock.Expression)
                .Returns(CustomerQuery.Expression);

            CustomerDbSetMock.As<IQueryable<Customer>>()
                .Setup(mock => mock.ElementType)
                .Returns(CustomerQuery.ElementType);

            CustomerDbSetMock.As<IQueryable<Customer>>()
                .Setup(mock => mock.GetEnumerator())
                .Returns(CustomerQuery.GetEnumerator());


            LaboratoryOrdersDbSetMock.As<IQueryable<LaboratoryOrders>>()
                .Setup(mock => mock.Provider)
                .Returns(LaboratoryOrdersQuery.Provider);

            LaboratoryOrdersDbSetMock.As<IQueryable<LaboratoryOrders>>()
                .Setup(mock => mock.Expression)
                .Returns(LaboratoryOrdersQuery.Expression);

            LaboratoryOrdersDbSetMock.As<IQueryable<LaboratoryOrders>>()
                .Setup(mock => mock.ElementType)
                .Returns(LaboratoryOrdersQuery.ElementType);

            LaboratoryOrdersDbSetMock.As<IQueryable<LaboratoryOrders>>()
                .Setup(mock => mock.GetEnumerator())
                .Returns(LaboratoryOrdersQuery.GetEnumerator());


            contextMock.Setup(mock => mock.Set<Services>()).Returns(ServicesDbSetMock.Object);
            contextMock.Setup(mock => mock.Set<LaboratoryStaff>()).Returns(LaboratoryStaffDbSetMock.Object);
            contextMock.Setup(mock => mock.Set<Customer>()).Returns(CustomerDbSetMock.Object);
            contextMock.Setup(mock => mock.Set<LaboratoryOrders>()).Returns(LaboratoryOrdersDbSetMock.Object);

            staffLogic = new LaboratoryStaffLogic(staffRepo);
            CustomerLogic = new CustomerLogic(customerRepo);
            serviceLogic = new ServiceLogic(servicesRepo);
            orderLogic = new LaboratoryOrderLogic(orderRepo);
        }

       
    }
}
