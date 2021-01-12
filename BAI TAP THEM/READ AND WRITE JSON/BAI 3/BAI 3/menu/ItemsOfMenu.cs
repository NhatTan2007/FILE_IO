using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3
{
    class ItemsOfMenu
    {
        public static int _currentMaxId = 0;
        private int _id;
        private string _name;
        private double _price;
        private string _unit;
        private double _discount;
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price * (1 - _discount); set => _price = value; }
        public string Unit { get => _unit; set => _unit = value; }

        public ItemsOfMenu(string name, double price, string unit)
        {
            _id = ++_currentMaxId;
            _name = name;
            _price = price;
            _unit = unit;
            _discount = 0;
        }

        public void SetDiscount(double discount)
        {
            _discount = discount;
        }

        public void SetCurrentMaxId(int currentMaxId)
        {
            _currentMaxId = currentMaxId;
        }
    }
}
