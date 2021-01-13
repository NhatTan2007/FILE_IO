using System;
using System.Collections.Generic;
using System.Text;
using BAI_3_UPDATE.Models;
using BAI_3_UPDATE.Services;

namespace BAI_3_UPDATE.Services
{
    class OrderServices
    {
        private Shop _shopOrder;
        private MenuShopServices _menuShopServices;
        public OrderServices(ref Shop inputShop)
        {
            _shopOrder = inputShop;
            _menuShopServices = new MenuShopServices(ref _shopOrder);
        }
        #region Public Method
        public bool CanMakeOrder()
        {
            if (_shopOrder.ListTables.Count <= 0 || !_menuShopServices.IsMenuEmpty()) return false;
            return true;
        }

        public void OrderDrinksOrFoods(ItemOfMenu itemOrder, Table tableOrder, int numberUnit = 1)
        {
            int indexOrder = LastIndexOrderOfTable(tableOrder.TableNumber);
            if (indexOrder != -1)
            {
                Order newestOrder = _shopOrder.OrderHistoryOfShop.ListOrders[indexOrder];
                if (!newestOrder.IsPaid)
                {
                    int index = IsItemExistsInOrderDetail(newestOrder,itemOrder.Name);
                    if (index != -1)
                    {
                        newestOrder.OrderDetail[index].Quantity += numberUnit;
                    }
                    else
                    {
                        ItemOrdered tempItemOrder = new ItemOrdered(itemOrder, numberUnit);
                        newestOrder.OrderDetail.Add(tempItemOrder);
                    }
                }
                else
                {
                    newestOrder = new Order(tableOrder);
                    ItemOrdered tempItemOrder = new ItemOrdered(itemOrder, numberUnit);
                    newestOrder.OrderDetail.Add(tempItemOrder);
                    _shopOrder.OrderHistoryOfShop.ListOrders.Add(newestOrder);
                }
            }
            else
            {
                Order newestOrder = new Order(tableOrder);
                ItemOrdered tempItemOrder = new ItemOrdered(itemOrder, numberUnit);
                newestOrder.OrderDetail.Add(tempItemOrder);
                _shopOrder.OrderHistoryOfShop.ListOrders.Add(newestOrder);
            }
        }

        public bool InputDataOrder(out int id, out int qty, out int tableNumber)
        {
            id = -1;
            qty = -1;
            tableNumber = -1;
            bool checkInput = false;
            Console.WriteLine("Enter 0 to cancel");
            do
            {
                Console.Write("Please enter id of item: ");
                checkInput = ConvertServices.ToIntByTryParse(Console.ReadLine(), out id);
            } while (!checkInput || id > ItemOfMenu._currentMaxId || id < 0);
            if (id == 0) return false;
            do
            {
                Console.Write($"Please enter number of item you want to order: ");
                checkInput = ConvertServices.ToIntByTryParse(Console.ReadLine(), out qty);
            } while (!checkInput || qty < 0);
            if (qty == 0) return false;
            do
            {
                Console.Write($"Please enter table you want to add: ");
                checkInput = ConvertServices.ToIntByTryParse(Console.ReadLine(), out tableNumber);
            } while (!checkInput || tableNumber < 0 || tableNumber > _shopOrder.ListTables.Count);
            if (tableNumber == 0) return false;
            return true;
        }

        public int LastIndexOrderOfTable(int tableNumber)
        {
            int index = -1;
            for (int i = 0; i < _shopOrder.OrderHistoryOfShop.ListOrders.Count; i++)
            {
                if (_shopOrder.OrderHistoryOfShop.ListOrders[i].TableNumber == tableNumber) index = i;
            }
            return index;
        }


        #endregion
        #region Private Method
        private int IsItemExistsInOrderDetail(Order orderToFind, string itemName)
        {

            for (int i = 0; i < orderToFind.OrderDetail.Count; i++)
            {
                if (orderToFind.OrderDetail[i].Name == itemName) return i;
            }
            return -1;
        }
        #endregion
    }
}
