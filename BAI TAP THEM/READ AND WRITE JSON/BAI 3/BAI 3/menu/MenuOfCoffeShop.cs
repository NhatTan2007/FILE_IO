using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3
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

        public bool IsItemExists(string name)
        {
            foreach (Drink item in _listDrinksOfShop)
            {
                if (item.Name == name) return true;
            }

            foreach (Food item in _listFoodsOfShop)
            {
                if (item.Name == name) return true;
            }
            return false;
        }

        public bool IsMenuEmpty()
        {
            if (_listDrinksOfShop.Count <= 0 && _listFoodsOfShop.Count <= 0) return true;
            return false;
        }

        public bool IsDrinksMenuEmpty()
        {
            if (_listDrinksOfShop.Count <= 0) return true;
            return false;
        }

        public bool IsFoodsMenuEmpty()
        {
            if (_listFoodsOfShop.Count <= 0) return true;
            return false;
        }

        public string DisplayDrinksMenu()
        {
            string result = "Drinks Menu\n";
            foreach (Drink item in _listDrinksOfShop)
            {
                result += $"ID: {item.Id}\t|\t{item.Name}\n";
            }
            return result;
        }

        public string DisplayFoodsMenu()
        {
            string result = "Foods Menu\n";
            foreach (Food item in _listFoodsOfShop)
            {
                result += $"ID: {item.Id}\t|\t{item.Name}\n";
            }
            return result;
        }

        public ItemsOfMenu GetItemById(int id)
        {
            foreach (Drink item in _listDrinksOfShop)
            {
                if (item.Id == id) return item;
            }

            foreach (Food item in _listFoodsOfShop)
            {
                if (item.Id == id) return item;
            }
            return null;
        }
    }

}
