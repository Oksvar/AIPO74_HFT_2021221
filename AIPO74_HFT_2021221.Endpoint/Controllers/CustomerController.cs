using Microsoft.AspNetCore.Mvc;
using AIPO74_HFT_2021221.Logic;
using AIPO74_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using AIPO74_HFT_2021221.Endpoint.Signal;

namespace AIPO74_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerLogic customerLogic;
        IHubContext<SignalRHub> hub;
        public CustomerController(ICustomerLogic customerLogic, IHubContext<SignalRHub> hub)
        {
            this.customerLogic = customerLogic;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("CustomerUpdated", customer);
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
            hub.Clients.All.SendAsync("CustomerCreated", customer);
        }
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            var customerToDelete = customerLogic.GetCustomerID(id);
            customerLogic.DeleteCustomer(id);
            hub.Clients.All.SendAsync("CustomerDeleted", customerToDelete);
        }
        [HttpGet("getcustomerbyorder/{id}")]
        public IEnumerable<GetCustomerByStaff> getCustomerByStaffs(int id)
        {
            return customerLogic.getCustomerByStaffs(id);
        }
      
     
    }
}