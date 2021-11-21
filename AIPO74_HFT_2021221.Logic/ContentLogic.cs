using AIPO74_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Repository;

namespace AIPO74_HFT_2021221.Logic
{
    public class ContentLogic : IContentLogic
    {
        private ILaboratoryStaffRepo LaboratoryStaffRepo;
        private IServices servicesRepo;

        public ContentLogic(ILaboratoryStaffRepo laboratoryStaffRepo, IServices servicesRepos)
        {
            this.LaboratoryStaffRepo = laboratoryStaffRepo;
            this.servicesRepo = servicesRepos;
        }
        public IList<Services> getAllServices()
        {
            return this.servicesRepo.GetAll().ToList();
        }

        public Services GetServices(int id)
        {
            Services Newservices = this.servicesRepo.GetOne(id);
            if (Newservices == null)
            {
                throw new InvalidOperationException("Error GetService type");
            }
            return this.servicesRepo.GetOne(id);
            
        }

        public LaboratoryStaff GetStaff(int id)
        {
            LaboratoryStaff laboratoryStaff = this.LaboratoryStaffRepo.GetOne(id);
            if (laboratoryStaff == null)
            {
                throw new InvalidOperationException("Error Get one staff type");
            }
            return this.LaboratoryStaffRepo.GetOne(id);
        }

        public IList<LaboratoryStaff> GetStaffs()
        {
            return this.LaboratoryStaffRepo.GetAll().ToList();
        }
    }
}
