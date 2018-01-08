using SONIC_Orders.Interfaces;

namespace SONIC_Orders
{
    public abstract class Item : IItem
    {
        private int _key;
        private string _name;
        private double _price;

        public Item(int key, string name, double price)
        {
            _key = key;
            _name = name;
            _price = price;
        }

        public int Key()
        {
            return _key;
        }
        
        public string Name()
        {
            return _name;
        }

        public virtual double Price()
        {
            return _price;
        }

        public abstract string ItemType();

    }
}