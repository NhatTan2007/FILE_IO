using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3
{
    class CoffeShop
    {
        private MenuOfCoffeShop _menu;
        private List<Table> _listTables;
        private OrderHistory _orderHistoryOfShop;

        public MenuOfCoffeShop Menu { get => _menu; set => _menu = value; }
        public List<Table> ListTables { get => _listTables; set => _listTables = value; }
        internal OrderHistory OrderHistoryOfShop { get => _orderHistoryOfShop; set => _orderHistoryOfShop = value; }

        //private List<Staff> _listStaff;
        public CoffeShop()
        {
            _menu = new MenuOfCoffeShop();
            _listTables = new List<Table>();
            _orderHistoryOfShop = new OrderHistory();
        }

        public void OrderDrinksOrFoods(ItemsOfMenu itemOrder, Table tableOrder, int numberUnit = 1)
        {
            int indexOrder = _orderHistoryOfShop.LastIndexOrderOfTable(tableOrder.TableNumber);
            if (indexOrder != -1)
            {
                Order newestOrder = _orderHistoryOfShop.ListOrders[indexOrder];
                if (!newestOrder.IsPaid)
                {
                    int index = newestOrder.IsItemExistsInOrderDetail(itemOrder.Name);
                    if (index != -1)
                    {
                        newestOrder.OrderDetail[index].Quantity += numberUnit;
                    } else
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
                    _orderHistoryOfShop.ListOrders.Add(newestOrder);
                }
            } 
            else
            {
                Order newestOrder = new Order(tableOrder);
                ItemOrdered tempItemOrder = new ItemOrdered(itemOrder, numberUnit);
                newestOrder.OrderDetail.Add(tempItemOrder);
                _orderHistoryOfShop.ListOrders.Add(newestOrder);
            }
        }

        public void AddMoreTable(int numberTablesToAdd)
        {
            for (int i = 0; i < numberTablesToAdd; i++)
            {
                _listTables.Add(new Table());
            }
        }

        public Payment CreatePayments(Order orderToCheck)
        {
            Payment temp = new Payment(orderToCheck);
            return temp;
        }

        public Table GetTableOrder(int tableNumber)
        {
            foreach (Table item in _listTables)
            {
                if (item.TableNumber == tableNumber) return item;
            }
            return null;
        }
    }
}
