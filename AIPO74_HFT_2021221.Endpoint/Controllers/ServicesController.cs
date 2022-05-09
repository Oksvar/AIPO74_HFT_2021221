using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIPO74_HFT_2021221.Endpoint.Signal;
using AIPO74_HFT_2021221.Logic;
using AIPO74_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AIPO74_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        IServiceLogic serviceLogic;
        IHubContext<SignalRHub> hub;

        public ServicesController(IServiceLogic serviceLogic, IHubContext<SignalRHub> hub)
        {
            this.serviceLogic = serviceLogic;
            this.hub = hub;
        }
        [HttpGet("{id}")]
        public Services GeService(int id)
        {
            return serviceLogic.GetServicesID(id);
        }
        [HttpGet]
        public IEnumerable<Services> GetServices()
        {
            return serviceLogic.GetServices();
        }
        [HttpPost]
        public void CreateService([FromBody] Services services)
        {
            serviceLogic.CreateService(services);
            hub.Clients.All.SendAsync("ServicesCreated", services);
        }
        [HttpPut("updateprice")]
        public void ChangePrice([FromBody] Services services)
        {
            serviceLogic.ChangePrice(services.ServiceId, services.Price);
        }
        [HttpPut]
        public void UpdateService([FromBody] Services services)
        {
            serviceLogic.ChangeServiceName(services.ServiceId, services.Name);
            hub.Clients.All.SendAsync("ServicesUpdated", services);
        }
        [HttpGet("getservices/{id}")]
        public IEnumerable<ServiceWithHighestPrice> getCustomerByStaffs(int id)
        {
            return serviceLogic.serviceWithHighestPrices(id);
        }
        [HttpGet("AVGprice")]
        public Services AVGprice()
        {
            return serviceLogic.AVGPrice();
        }
        [HttpGet("getDangerous")]
        public IEnumerable<DangerousList> GetDangerous()
        {
            return serviceLogic.getDangerous();
        }
        [HttpDelete("{id}")]
        public void DeleteService(int id)
        {
            var serviceToDelete = serviceLogic.GetServicesID(id);
            serviceLogic.DeleteService(id);
            hub.Clients.All.SendAsync("ServicesDeleted", serviceToDelete);

        }
    }
}