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

namespace AIPO74_HFT_2021221.Test
{
    [TestFixture]
    public class LabServiceLogicTests
    {
        private Mock<ICustomerRepo> customerRepo;
        private Mock<ILaboratoryOrderRepo> LabOrderRepo;
        private Mock<IServices> serviceRepo;
        private Mock<IConnectionRepository> connectRepo;
        private Mock<ILaboratoryStaffRepo> staffRepo;
        LaboratoryServiceLogic LaboratoryServiceLogic;
        ClientLogic ClientLogic;
        ContentLogic content;
        private List<CustomerOrderResults> customerOrderResults;



        [Test]
        public void FirstTestOderTest()
        {
            var orderResult = this.LaboratoryServiceLogic.OrderResults();

            Assert.That(orderResult, Is.EquivalentTo(this.customerOrderResults));

            this.customerRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.LabOrderRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.serviceRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.connectRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.staffRepo.Verify(repo => repo.GetAll(), Times.Once);
        }
        #region
        [Test]
        public void GetAllCustomerTest()
        {
            var testemp = LaboratoryServiceLogic.GetAllCustomers();
            Assert.That(LaboratoryServiceLogic.GetAllCustomers().Count() > 0, Is.True);
        }

        public void GetAllOrdersTest()
        {
            var testmap = LaboratoryServiceLogic.GetAllOrders();
            Assert.That(LaboratoryServiceLogic.GetAllOrders().Count() > 0, Is.True);
        }
        
        public void GetAllservicesTest()
        {
            var testmap = content.getAllServices();
            Assert.That(content.getAllServices().Count() > 0, Is.True);
        }
        #endregion


        [Test]
        public void ThirdTest()
        {

        }
        [Test]
        public void fourthTest()
        {

        }
        [Test]
        public void fifthTest()
        {

        }
        [OneTimeSetUp]
        public void MockLogic()
        {
            
        }
    }
}
