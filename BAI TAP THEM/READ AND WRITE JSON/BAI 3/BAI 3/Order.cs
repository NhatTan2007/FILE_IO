using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3
{
    class Order
    {
        private int _tableNumber;
        private string _dateTimeStartOrder;
        private string _dateTimeEndOrder;
        private bool _isPaid;
        private List<ItemOrdered> _orderDetail;

        public int TableNumber { get => _tableNumber; set => _tableNumber = value; }
        public string DateTimeStartOrder { get => _dateTimeStartOrder; set => _dateTimeStartOrder = value; }
        public string DateTimeEndOrder { get => _dateTimeEndOrder; set => _dateTimeEndOrder = value; }
        public List<ItemOrdered> OrderDetail { get => _orderDetail; set => _orderDetail = value; }
        public bool IsPaid { get => _isPaid; set => _isPaid = value; }

        public Order()
        {
            _orderDetail = new List<ItemOrdered>();
        }

        public Order(Table tableOrder)
        {
            _dateTimeStartOrder = DateTime.UtcNow.ToString("g");
            _dateTimeEndOrder = String.Empty;
            _tableNumber = tableOrder.TableNumber;
            _isPaid = false;
            _orderDetail = new List<ItemOrdered>();
        }

        public int IsItemExistsInOrderDetail(string itemName)
        {
            for (int i = 0; i < _orderDetail.Count; i++)
            {
                if (_orderDetail[i].Name == itemName) return i;
            }
            return -1;
        }


    }
}
