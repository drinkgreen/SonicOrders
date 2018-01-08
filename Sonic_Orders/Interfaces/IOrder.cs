using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SONIC_Orders.Interfaces
{
    public interface IOrder : ISerializable
    {
        double getOrderTotal(double taxRate);

        IEnumerable<OrderItem> getItems();
    }
}
