using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SONIC_Orders.Items
{
    public class ServiceItem : Item 
    {
        public ServiceItem(int key, string name, double price) : base(key, name, price)
        {

        }

        public override string ItemType()
        {
            return "Service";
        }
    }
}
