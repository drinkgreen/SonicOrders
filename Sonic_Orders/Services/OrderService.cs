using SONIC_Orders.Interfaces.Services;
using SONIC_Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SONIC_Orders.Services
{
    public class OrderService : IOrderService
    {
        public double CalculateTotalItemAmount(OrderItem[] orderItems, double taxRate)
        {
            Globals.TAX_RATE = taxRate;
            double totalAmount = 0;

            foreach(OrderItem oItem in orderItems)
            {
                totalAmount += (oItem.ItemObject.Price() * oItem.Quantity);
            }
            return totalAmount;
        }

        //public double CalculateTotalMaterialItemAmount(OrderItem[] materialItems, double taxRate)
        //{
        //    Globals.TAX_RATE = taxRate;

        //}

        //public double CalculateTotalServiceItemAmount(OrderItem[] serviceItems)
        //{

        //}

    }
}
