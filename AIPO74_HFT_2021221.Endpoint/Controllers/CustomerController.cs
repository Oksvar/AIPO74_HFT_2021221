using Microsoft.AspNetCore.Mvc;
using AIPO74_HFT_2021221.Logic;
using AIPO74_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIPO74_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerLogic customerLogic;

        public CustomerController(ICustomerLogic customerLogic)
        {
            this.customerLogic = customerLogic;
        }
        [HttpGet ("{id}")]
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
        [HttpPut("changephone")]
        public void UpdatePhone([FromBody] Customer customer)
        {
            customerLogic.ChangePhone(customer.CustomerID, customer.Phone);
        }
        [HttpPut("changesecret")]
        public void UpdateSercre ([FromBody] Customer customer)
        {
            customerLogic.ChangeSecrecyStamp(customer.CustomerID, customer.SecrecyStamp);
        }
        [HttpPost]
        public void CreateCustomer([FromBody] Customer customer)
        {
            customerLogic.CreateCustomer(customer);
        }
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            customerLogic.DeleteCustomer(id);
        }
        [HttpGet("getcustomerbyorder/{id}")]
        public IEnumerable<GetCustomerByStaff> getCustomerByStaffs(int id)
        {
            return customerLogic.getCustomerByStaffs(id);
        }
      
     
    }
}