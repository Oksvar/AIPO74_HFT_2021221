using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Models;

namespace AIPO74_HFT_2021221.Logic
{
  public  interface IServiceLogic
    {
        IEnumerable<Services> GetServices();

        Services GetServicesID(int id);

        void CreateService(Services services);

        void ChangeServiceName(int id, string newServName);

        void DeleteService(int id);
    }
}
