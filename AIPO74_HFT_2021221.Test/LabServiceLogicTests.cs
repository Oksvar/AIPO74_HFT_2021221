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
        IServices servicesRepo;
        ILaboratoryStaffRepo staffRepo;
        ILaboratoryOrderRepo orderRepo;
        ICustomerRepo customerRepo;
        LaboratoryStaffLogic staffLogic;
        CustomerLogic CustomerLogic;
        IServiceLogic serviceLogic;
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
