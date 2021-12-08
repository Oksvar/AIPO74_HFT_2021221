using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Models
{
    public class DangerousList
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int orderID { get; set; }

        public override string ToString()
        {
            return  "Customer ID: "+ CustomerID;
        }
    }
}
