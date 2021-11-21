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
        private LaboratoryServiceLogic LaboratoryServiceLogic;

        [Test]
        public void FirstTest()
        {

        }
        [Test]
        public void SecondTest()
        {

        }
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
