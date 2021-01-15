using System;
using System.Collections.Generic;
using System.Text;
using BAI_3_UPDATE.Models;
using BAI_3_UPDATE.Services;

namespace BAI_3_UPDATE.Services
{
    class MenuShopServices
    {
        private Shop _shopUseServices;
        private MenuOfCoffeShop _menu;
        public MenuShopServices(ref Shop inputShop)
        {
            _shopUseServices = inputShop;
            _menu = _shopUseServices.Menu;
        }
        #region Public Method
        public void AddItemToMenuShop()
        {
            string name = string.Empty;
            double price;
            string unit;
            bool checkInput = false;
            int yourChoice = -1;
            do
            {
                Console.Write("Please enter name of item: ");
                name = ValidDataServices.FormatName(Console.ReadLine());
            } while (name == "");

            if (!IsItemExists(name))
            {
                do
                {
                    Console.Write("Please enter item's price: ");
                    checkInput = ConvertServices.ToDoubleByTryParse(Console.ReadLine(), out price);
                } while (!checkInput || price <= 0);
                do
                {
                    Console.Write("Please enter unit type of item: ");
                    unit = Console.ReadLine().Trim();
                    checkInput = ConvertServices.ToIntByTryParse(unit, out int temp);
                } while (unit == "" || checkInput);
                switch (yourChoice)
                {
                    case 1:
                        Drink newDrink = new Drink(nameInput: name, priceInput: price, unitInput: unit);
                        _menu.ListDrinksOfShop.Add(newDrink);
                        Console.WriteLine("Your drink item has add to Drinks Menu");
                        break;
                    case 2:
                        Food newFood = new Food(nameInput: name, priceInput: price, unitInput: unit);
                        _menu.ListFoodsOfShop.Add(newFood);
                        Console.WriteLine("Your food item has add to Foods Menu");
                        break;
                }
                FileJsonServices.WriteFileJson(_shopUseServices, FilePath.StrDataFileFullPath);
            }
            else
            {
                Console.WriteLine($"Shop have item with name {name}, please change another name");
            }

        }

        public bool IsItemExists(string nameItem)
        {
            foreach (Drink item in _menu.ListDrinksOfShop)
            {
                if (item.Name == nameItem) return true;
            }

            foreach (Food item in _menu.ListFoodsOfShop)
            {
                if (item.Name == nameItem) return true;
            }
            return false;
        }

        public bool IsMenuEmpty()
        {
            if (_menu.ListDrinksOfShop.Count <= 0 && _menu.ListFoodsOfShop.Count <= 0) return true;
            return false;
        }

        private string ToStringDrinksMenu()
        {
            string result = "Drinks Menu\n";
            foreach (Drink item in _menu.ListDrinksOfShop)
            {
                result += $"ID: {item.Id}\t|\t{item.Name}\n";
            }
            return result;
        }

        private string ToStringFoodsMenu()
        {
            string result = "Foods Menu\n";
            foreach (Food item in _menu.ListFoodsOfShop)
            {
                result += $"ID: {item.Id}\t|\t{item.Name}\n";
            }
            return result;
        }

        public void DisplayProductsMenu()
        {
            Console.WriteLine(ToStringDrinksMenu());
            Console.WriteLine();
            Console.WriteLine(ToStringFoodsMenu());
        }

        public ItemOfMenu GetItemById(int id)
        {
            foreach (Drink item in _menu.ListDrinksOfShop)
            {
                if (item.Id == id) return item;
            }

            foreach (Food item in _menu.ListFoodsOfShop)
            {
                if (item.Id == id) return item;
            }
            return null;
        }
        #endregion
    }
}
