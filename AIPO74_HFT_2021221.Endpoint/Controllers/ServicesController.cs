using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIPO74_HFT_2021221.Logic;
using AIPO74_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;

namespace AIPO74_HFT_2021221.Endpoint.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceLogic serviceLogic;

        public ServicesController(IServiceLogic serviceLogic)
        {
            this.serviceLogic = serviceLogic;
        }
        [HttpGet("{BYID}")]
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
        }
        [HttpPut]
        public void UpdateService([FromBody] Services services)
        {
            serviceLogic.ChangeServiceName(services.ServiceId, services.Name);
        }
        [HttpDelete("{BYID}")]
        public void DeleteService(int id)
        {
            serviceLogic.DeleteService(id);
        }
    }
}