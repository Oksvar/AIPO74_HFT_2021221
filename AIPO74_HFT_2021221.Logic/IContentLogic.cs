using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Models;

namespace AIPO74_HFT_2021221.Logic
{
   public interface IContentLogic
    {
        Services GetServices(int id);

        IList<Services> getAllServices();

        LaboratoryStaff GetStaff(int id);

        IList<LaboratoryStaff> GetStaffs();
    }
}
