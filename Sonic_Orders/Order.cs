using SONIC_Orders.Interfaces;
using SONIC_Orders.Interfaces.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SONIC_Orders
{
    [Serializable]
    public class Order : IOrder
    {
        private OrderItem[] _orderItems;
        private IOrderService _OrderService;
        private Hashtable _orderTable;

        public Order(OrderItem[] orderItems, IOrderService orderService)
        {
            _orderItems = orderItems;
            _OrderService = orderService;
            setupHashTable();
        }

        public IEnumerable<OrderItem> OrderItems
        {
            get
            {
                return _orderItems;
            }
        }

        public Hashtable OrderTable
        {
            get
            {
                return _orderTable;
            }
        }

        // Returns the total order cost after the tax has been applied

        public double getOrderTotal(double taxRate)
        {
            return _OrderService.CalculateTotalItemAmount(_orderItems, taxRate);
        }

        public IEnumerable<OrderItem> getItems()
        {
            return this.OrderItems.OrderBy(o => o.ItemObject.Name());
        }

        public virtual void GetObjectData(SerializationInfo si, StreamingContext context)
        {
            
        }

        private void setupHashTable()
        {
            _orderTable = new Hashtable();
            foreach(OrderItem item in OrderItems)
            {
                _orderTable[item] = item.Quantity;
            }
        }
    }
}
