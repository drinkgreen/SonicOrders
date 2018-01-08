using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SONIC_Orders;
using Moq;
using FluentAssertions;
using SONIC_Orders.Interfaces;
using SONIC_Orders.Items;
using System.Collections;
using System.Collections.Generic;
using SONIC_Orders.Services;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace OrdersTests
{
    [TestClass]
    public class OrderTest
    {
        OrderItem[] orderItems = new OrderItem[]
            {
                new OrderItem(new MaterialItem(1, "Material_1", 1.25), 1),
                new OrderItem(new MaterialItem(2, "Material_2", 1.30), 2),
                new OrderItem(new ServiceItem(3, "Service_1", 1.25),3),
                new OrderItem(new ServiceItem(4, "ZZZ", 4.0), 1),
                new OrderItem(new ServiceItem(5, "QQQ",1),1),
                new OrderItem(new ServiceItem(6, "AAA",1),1)
            };
        [TestMethod]
        public void SortOrderItemsByName()
        {
            Mock<OrderService> orderService = new Mock<OrderService>();
            Order order = new Order(orderItems, orderService.Object);

            IEnumerable<OrderItem> sortedOrders = order.getItems();

            Assert.AreEqual(1, orderItems.First().ItemObject.Key());
            Assert.AreEqual(6, orderItems.Last().ItemObject.Key());
            Assert.AreEqual(6, sortedOrders.First().ItemObject.Key());
            Assert.AreEqual(4, sortedOrders.Last().ItemObject.Key());
           
        }

        [TestMethod]
        public void CalculateTotalOrderAmount()
        {
            Mock<OrderService> orderService = new Mock<OrderService>();
            Order order = new Order(orderItems, orderService.Object);

            double test = order.getOrderTotal(0.0885);

            Assert.AreEqual(13.95, test);
        }

        [TestMethod]
        public void SerializeOrder()
        {
            Mock<OrderService> orderService = new Mock<OrderService>();
            Order order = new Order(orderItems, orderService.Object);

            MemoryStream mem = new MemoryStream();
            BinaryFormatter bin = new BinaryFormatter();
            try
            {
                bin.Serialize(mem, order);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
            
    }
}
