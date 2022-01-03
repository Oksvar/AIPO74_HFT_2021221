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
        ILaboratoryOrderRepo laboratoryOrderRepo;
        ICustomerRepo customerRepo;
        public ServiceLogic(IServices serviceRepo, ILaboratoryOrderRepo orderRepo, ICustomerRepo customerRepo)
        {
          this.servicesRepo = serviceRepo;
            this.laboratoryOrderRepo = orderRepo;
            this.customerRepo = customerRepo;
        }

        public void ChangePrice(int id, int newPrice)
        {
            servicesRepo.ChangePrice(id, newPrice);
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

        //non Crud  method checking dangerous
        public IEnumerable<DangerousList> getDangerous()
        {
                IQueryable<Services> services = servicesRepo.GetAll();
                IQueryable<LaboratoryOrders> Orders = laboratoryOrderRepo.GetAll();
                var quer = from order in Orders
                           join serv in services on order.ServiceId equals serv.ServiceId
                       where serv.Dangerous > 7 
                           select new DangerousList
                           {
                              orderID = order.Id,
                              Dangerous = serv.Dangerous,
                              ServiceName = serv.Name
                          
                           };
                return quer.ToList();
        }
        

        public IEnumerable<Services> GetServices()
        {
            return servicesRepo.GetAll();
        }

        public Services GetServicesID(int id)
        {
            return servicesRepo.GetOne(id);
        }

        //non crud Show service data
        public IEnumerable<ServiceWithHighestPrice> serviceWithHighestPrices(int id)
        {
            IQueryable<Services> services = servicesRepo.GetAll();
            IQueryable<LaboratoryOrders> orders = laboratoryOrderRepo.GetAll();
            var quer = from Custom in services
                       join order in orders on Custom.ServiceId
                       equals order.ServiceId
                       where order.Id == id
                       select new ServiceWithHighestPrice
                       {
                           serviceID = Custom.ServiceId,
                           serviceName = Custom.Name,
                           price = Custom.Price

                       };
            return quer.ToList();

            

        }
        //non-crud showing avarage price
        public Services AVGPrice()
        {
            Services services = new Services() 
            { Price = Convert.ToInt32(servicesRepo.GetAll().Average(t => t.Price)) };
            return services;
        }
    }
}
