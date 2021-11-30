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
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerLogic customerLogic;

        public CustomerController(ICustomerLogic customerLogic)
        {
            this.customerLogic = customerLogic;
        }
        [HttpGet ("{BYID}")]
        public Customer GetCustomer(int id)
        {
            return customerLogic.GetCustomerID(id);
        }
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return customerLogic.GetCustomers();
        }
        [HttpPut]
        public void UpdateCustomer([FromBody] Customer customer)
        {
            customerLogic.ChangeAddress(customer.CustomerID, customer.Address);
        }
        [HttpPost]
        public void CreateCustomer([FromBody] Customer customer)
        {
            customerLogic.CreateCustomer(customer);
        }
        [HttpDelete("BYID")]
        public void DeleteCustomer(int id)
        {
            customerLogic.DeleteCustomer(id);
        }

     
    }
}