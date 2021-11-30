using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIPO74_HFT_2021221.Logic;
using AIPO74_HFT_2021221.Models;


namespace AIPO74_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LaboratoryOrderController : ControllerBase
    {
        private readonly ILaboratoryOrderLogic laboratoryOrderLogic;
        public LaboratoryOrderController(ILaboratoryOrderLogic laboratoryOrderLogic)
        {
            this.laboratoryOrderLogic = laboratoryOrderLogic;
        }
        [HttpGet("BYID")]
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
        }
        [HttpPut]
        public void UpdateDate([FromBody] LaboratoryOrders laboratoryOrders)
        {
            laboratoryOrderLogic.ChangeDate(laboratoryOrders.Id, laboratoryOrders.Date);
        }
        [HttpDelete]
        public void DeleteOrder(int id)
        {
            laboratoryOrderLogic.DeleteOrder(id);
        }
    }
}