using AIPO74_HFT_2021221.Models;
using AIPO74_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Logic
{
    public class ServiceLogic : IServiceLogic
    {
        private readonly IServices services1;
        public ServiceLogic(IServices serviceLogic)
        {
            this.services1 = serviceLogic;
        }
        public void ChangeServiceName(int id, string newServName)
        {
            throw new NotImplementedException();
        }

        public void CreateService(Services services)
        {
            if (services1.GetOne(services.ServiceId) != null)
            {
                throw new InvalidOperationException("ERROR: This service already in database ");
            }
            else if (services.Name == null) 
            {
                throw new InvalidOperationException("ERROR: Some fields are not filled ");
            }
            services1.Add(services);
        }

        public void DeleteService(int id)
        {
            services1.Remove(id);
        }

        public IEnumerable<Services> GetServices()
        {
            return services1.GetAll();
        }

        public Services GetServicesID(int id)
        {
            return services1.GetOne(id);
        }
    }
}
