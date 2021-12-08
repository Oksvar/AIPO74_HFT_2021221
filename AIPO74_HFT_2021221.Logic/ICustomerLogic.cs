using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Models;

namespace AIPO74_HFT_2021221.Logic
{
    public interface ICustomerLogic
    {
        void ChangeAddress(int id, string newAddress);

        void ChangePhone(int id, string phone);

        void ChangeSecrecyStamp(int id, string newSecrecyStamp);

        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerID(int id);

        void CreateCustomer(Customer customer);
        void DeleteCustomer(int id);
        IEnumerable<GetCustomerByStaff> getCustomerByStaffs(int idorder);
    }  
}
