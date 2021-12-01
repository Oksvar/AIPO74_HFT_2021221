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
        IServices servicesRepo;
        public ServiceLogic(IServices serviceRepo)
        {
            servicesRepo = serviceRepo;
        }
        public void ChangeServiceName(int id, string newServName)
        {
            servicesRepo.ChangeName(id, newServName);
        }

        public void CreateService(Services services)
        {
            if (servicesRepo.GetOne(services.ServiceId) != null)
            {
                throw new InvalidOperationException("ERROR: This service already in database ");
            }
            else if (services.Name == null) 
            {
                throw new InvalidOperationException("ERROR: Some fields are not filled ");
            }
            servicesRepo.Add(services);
        }

        public void DeleteService(int id)
        {
            servicesRepo.Remove(id);
        }

        public IEnumerable<Services> GetServices()
        {
            return servicesRepo.GetAll();
        }

        public Services GetServicesID(int id)
        {
            return servicesRepo.GetOne(id);
        }
    }
}
