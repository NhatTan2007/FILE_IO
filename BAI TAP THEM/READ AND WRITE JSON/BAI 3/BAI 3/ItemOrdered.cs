﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3
{
    class ItemOrdered
    {
        private string _name;
        private double _pricePerUnit;
        private string _unit;
        private int _quantity = 0;
        private double _amount => GetAmount();
        public string Name { get => _name; set => _name = value; }
        public double PricePerUnit { get => _pricePerUnit; set => _pricePerUnit = value; }
        public string Unit { get => _unit; set => _unit = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public double Amount { get => _amount;}

        public ItemOrdered()
        {

        }
        public ItemOrdered(ItemsOfMenu item, int numberUnitOrder)
        {
            _name = item.Name;
            _pricePerUnit = item.Price;
            _unit = item.Unit;
            _quantity += numberUnitOrder;
        }

        public double GetAmount()
        {
            return _pricePerUnit * _quantity;
        }
    }
}
