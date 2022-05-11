using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIPO74_HFT_2021221.Logic;
using AIPO74_HFT_2021221.Models;
using Microsoft.AspNetCore.SignalR;
using AIPO74_HFT_2021221.Endpoint.Signal;

namespace AIPO74_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
   // [ApiController]
    public class LaboratoryOrderController : ControllerBase
    {

        private readonly ILaboratoryOrderLogic laboratoryOrderLogic;
        IHubContext<SignalRHub> hub;
        public LaboratoryOrderController(ILaboratoryOrderLogic laboratoryOrderLogic)
        {
            this.laboratoryOrderLogic = laboratoryOrderLogic;
        }
        [HttpGet("{id}")]
        public LaboratoryOrders GetOrder(int id)
        {
            return laboratoryOrderLogic.GetLaboratoryOrder(id);
        }
        [HttpGet]
        public IEnumerable<LaboratoryOrders> GetOrders()
        {
            return laboratoryOrderLogic.GetLaboratoryOrders();
        }
        [HttpPost]
        public void CreateOrder([FromBody] LaboratoryOrders laboratoryOrders)
        {
            laboratoryOrderLogic.CreateNewOrder(laboratoryOrders);
            hub.Clients.All.SendAsync("LaboratoryOrdersCreated", laboratoryOrders);
        }
        [HttpPut]
        public void UpdateDate([FromBody] LaboratoryOrders laboratoryOrders)
        {
            laboratoryOrderLogic.ChangeDate(laboratoryOrders.Id, laboratoryOrders.Date);
            hub.Clients.All.SendAsync("LaboratoryOrdersUpdated", laboratoryOrders);
        }
        [HttpGet("allinfoorder/{id}")]
        public IEnumerable<AlIinformationAboutOrder> GetAllinformationAboutOrder(int id)
        {
            return laboratoryOrderLogic.GetAllInfoaboutOrder(id);
        }
        [HttpDelete("{id}")]
        public void DeleteOrder(int id)
        {
            var orderToDelete = laboratoryOrderLogic.GetLaboratoryOrder(id);
            laboratoryOrderLogic.DeleteOrder(id);
            hub.Clients.All.SendAsync("LaboratoryOrdersDeleted", orderToDelete);
        }
    }
}