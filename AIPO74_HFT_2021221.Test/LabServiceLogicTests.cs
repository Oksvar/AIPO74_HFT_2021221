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



       
        #region CRUD
         [Test]
         public void GetServiceId()
        {
            var staff = serviceLogic.GetServicesID(1);
            Assert.That(staff.Name, Is.EqualTo("Biological Weapon"));
        }
        [Test]
        public void GetCustumerID()
        {
            var cust = CustomerLogic.GetCustomers();
            Assert.That(CustomerLogic.GetCustomers().Count() > 0, Is.True);

        }
        #endregion


       
        public void ThirdTest()
        {

        }
        
        public void fourthTest()
        {

        }
       
        public void fifthTest()
        {

        }
        [OneTimeSetUp]
        public void MockLogic()
        {
            
        }
    }
}
