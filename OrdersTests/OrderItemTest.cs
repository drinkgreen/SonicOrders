using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SONIC_Orders;
using SONIC_Orders.Items;
using Moq;
using FluentAssertions;
using SONIC_Orders.Interfaces;

namespace OrdersTests
{
    [TestClass]
    public class OrderItemTest
    {
        Mock<IItem> item = new Mock<IItem>();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullOrMissingItemThrowsError()
        {
            var orderItem = new OrderItem(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QuantityAsZeroThrowsError()
        {
            var orderItem = new OrderItem(item.Object, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QuantityAsLessThanZeroThrowsError()
        {
            var orderItem = new OrderItem(item.Object, -1);
        }

        [TestMethod]
        public void MaterialITem_RoundingPriceDown()
        {
            var price = 1.25;
            var tax = 1.0885;
            var MaterialItem = new MaterialItem(1, "Test", price);
            var orderItem = new OrderItem(MaterialItem, 1);

            //Material Items are Taxed.  1.25 + 0.0885 tax rate is equal to 1.360625
            Assert.AreEqual(1.36, orderItem.ItemObject.Price());
            Assert.AreEqual(Math.Round(price * tax, 2), orderItem.ItemObject.Price());
        }

        [TestMethod]
        public void MaterialItem_RoundingPriceUp()
        {
            var price = 1.30;
            var tax = 1.0885;
            var MaterialItem = new MaterialItem(1, "Test", price);
            var orderItem = new OrderItem(MaterialItem, 1);

            //Material Items are Taxed.  1.30 + 0.0885 tax rate is equal to 1.41505
            Assert.AreEqual(1.42, orderItem.ItemObject.Price());
            Assert.AreEqual(Math.Round(price * tax, 2), orderItem.ItemObject.Price());
        }


    }
}
