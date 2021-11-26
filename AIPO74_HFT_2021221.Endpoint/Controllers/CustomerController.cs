using Microsoft.AspNetCore.Mvc;
using AIPO74_HFT_2021221.Logic;
using AIPO74_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
;

namespace AIPO74_HFT_2021221.Endpoint.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerLogic customerLogic;

        public CustomerController(ICustomerLogic customerLogic)
        {
            this.customerLogic = customerLogic;
        }
        [HttpGet ("{id}")]
        public Customer GetCustomer(int id)
        {
            return customerLogic.GetCustomerID(id);
        }

     
    }
}