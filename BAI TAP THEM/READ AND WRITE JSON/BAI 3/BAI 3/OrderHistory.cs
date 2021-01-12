using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3
{
    class OrderHistory
    {
        private List<Order> _listOrders;
        public List<Order> ListOrders { get => _listOrders; set => _listOrders = value; }
        public OrderHistory()
        {
            _listOrders = new List<Order>();
        }

        public int LastIndexOrderOfTable (int tableNumber)
        {
            int index = -1;
            for (int i = 0; i < _listOrders.Count; i++)
            {
                if (_listOrders[i].TableNumber == tableNumber) index = i;
            }
            return index;
        }
    }
}
