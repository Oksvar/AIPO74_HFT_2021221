using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Models
{
   public class GetCustomerByStaff
    {
        public int orderId { get; set; }
        public string CustomerFullName { get; set; }


        public override string ToString()
        {
            return "Customer: " + CustomerFullName + " Customer order ID: " + orderId;
        }
    }
}
