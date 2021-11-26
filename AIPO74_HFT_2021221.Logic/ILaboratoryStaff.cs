using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Models;

namespace AIPO74_HFT_2021221.Logic
{
   public interface ILaboratoryStaff
    {
        IEnumerable<LaboratoryStaff> GetLaboratoryStaffs();
        LaboratoryStaff GetStaffID(int id);

        void CreateNewStaff(LaboratoryStaff laboratoryStaff);

        void ChangePosition(int id, string newPosition);

        void ChangeAccessLevel(int id, string newAccesslevel);

        void DeleteStaff(int id);

    }
}
