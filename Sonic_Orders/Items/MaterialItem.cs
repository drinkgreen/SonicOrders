using SONIC_Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SONIC_Orders;


namespace SONIC_Orders.Items
{
    public class MaterialItem : Item
    {
        public MaterialItem(int key, string name, double price) : base(key, name, price)
        {

        }

        public override string ItemType()
        {
            return "Material";
        }

        public override double Price()
        {
            return Math.Round((base.Price() * (1 + Globals.TAX_RATE)),2);
        }
    }
}
