using SONIC_Orders.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace SONIC_Orders
{
    public class OrderItem : IOrderItem
    {
        private IItem _item;
        private int _quantity;

        public OrderItem(IItem item, int quantity)
        {
            ItemObject = item;
            Quantity = quantity;
        }

        public IItem ItemObject {
            get { return _item; }
            set {
                if (ValidateItemObject(value))
                {
                    _item = value;
                }
            }
        }

        public int Quantity {
            get { return _quantity; }
            set
            {
                if (ValidateQuantity(value))
                {
                    _quantity = value;
                }
            }
        }

        #region "Field Validation"
        private bool ValidateQuantity(int value)
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException("Quanity cannot be empty or less than 1");
                }
                else
                {
                    return true;
                }
            }

            private bool ValidateItemObject(IItem value)
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("Item cannot be Null");
                }
                else {
                    return true;
                }
            }
        #endregion
        
    }
}