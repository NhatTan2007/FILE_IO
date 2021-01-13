using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3_UPDATE.Models
{
    class OrderHistory
    {
        private List<Order> _listOrders;
        public List<Order> ListOrders { get => _listOrders; set => _listOrders = value; }
        public OrderHistory()
        {
            _listOrders = new List<Order>();
        }
    }
}