using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3_UPDATE.Models
{
    class MenuOfCoffeShop
    {
        private List<Drink> _listDrinksOfShop;
        private List<Food> _listFoodsOfShop;

        public List<Drink> ListDrinksOfShop { get => _listDrinksOfShop; set => _listDrinksOfShop = value; }
        public List<Food> ListFoodsOfShop { get => _listFoodsOfShop; set => _listFoodsOfShop = value; }
        public MenuOfCoffeShop()
        {
            _listDrinksOfShop = new List<Drink>();
            _listFoodsOfShop = new List<Food>();
        }
    }
}