using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Models
{
    public class ServiceWithHighestPrice
    {
        public int serviceID { get; set;}
        public string serviceName { get; set; }

        public int price { get; set; }

        public override string ToString()
        {
            return " Service ID: " + serviceID + " Service name: " + serviceName + " Price: " + price;
        }
    }
}
