using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SONIC_Orders;

namespace SONIC_Orders.Interfaces.Services
{
    public interface IOrderService
    {
        double CalculateTotalItemAmount(OrderItem[] orderItems, double taxRate);

        //double CalculateTotalMaterialItemAmount(OrderItem[] materialItems, double taxRate);

       // double CalculateTotalServiceItemAmount(OrderItem[] serviceItems);
    }
}
