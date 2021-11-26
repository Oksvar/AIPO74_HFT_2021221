using AIPO74_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Repository;

namespace AIPO74_HFT_2021221.Logic
{
    public class LaboratoryStaffLogic : ILaboratoryStaff
    {
        private readonly ILaboratoryStaffRepo laboratoryStaff1;
        public LaboratoryStaffLogic(ILaboratoryStaffRepo laboratory)
        {
            this.laboratoryStaff1 = laboratory;
        }
        public void ChangeAccessLevel(int id, string newAccesslevel)
        {
            laboratoryStaff1.ChangeAccessLevel(id, newAccesslevel);
        }

        public void ChangePosition(int id, string newPosition)
        {
            laboratoryStaff1.ChangePosition(id, newPosition);
        }

        public void CreateNewStaff(LaboratoryStaff laboratoryStaff)
        {
            if (laboratoryStaff1.GetOne(laboratoryStaff.Id) !=null)
            {
                throw new InvalidOperationException("ERROR: thre is already staff with tihs ID");
            }
            else if(laboratoryStaff.FullName == null)
            {
                throw new InvalidOperationException("ERROR: Some fields are not filled");
            }
        }

        public void DeleteStaff(int id)
        {
            laboratoryStaff1.Remove(id);
        }

        public IEnumerable<LaboratoryStaff> GetLaboratoryStaffs()
        {
            return laboratoryStaff1.GetAll();
        }

        public LaboratoryStaff GetStaffID(int id)
        {
            return laboratoryStaff1.GetOne(id);
        }
    }
}
