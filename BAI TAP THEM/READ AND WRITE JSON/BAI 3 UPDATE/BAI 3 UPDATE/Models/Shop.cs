using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3_UPDATE.Models
{
    class Shop
    {
        private MenuOfCoffeShop _menu;
        private List<Table> _listTables;
        private OrderHistory _orderHistoryOfShop;

        public MenuOfCoffeShop Menu { get => _menu; set => _menu = value; }
        public List<Table> ListTables { get => _listTables; set => _listTables = value; }
        internal OrderHistory OrderHistoryOfShop { get => _orderHistoryOfShop; set => _orderHistoryOfShop = value; }

        //private List<Staff> _listStaff;
        public Shop()
        {
            _menu = new MenuOfCoffeShop();
            _listTables = new List<Table>();
            _orderHistoryOfShop = new OrderHistory();
        }
    }
}
