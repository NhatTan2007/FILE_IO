using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3
{
    class Payment
    {
        private int _tableNumber;
        private double _totalPrice => CalTotalPrice();
        private List<ItemOrdered> _detailsPayments;
        private string _dateTimeCreatePayment;

        public int TableNumber { get => _tableNumber; set => _tableNumber = value; }
        public double TotalPrice { get => _totalPrice;}
        public string DateTimeCreatePayment { get => _dateTimeCreatePayment; }
        public List<ItemOrdered> DetailsPayments { get => _detailsPayments; }

        //private string _staffCreatePayments;

        public Payment(Order orderToCheckout)
        {
            DateTime time = new DateTime();
            time = DateTime.Now;
            _dateTimeCreatePayment = time.ToString("g");
            _detailsPayments = new List<ItemOrdered>(orderToCheckout.OrderDetail);
            _tableNumber = orderToCheckout.TableNumber;
        }

        public double CalTotalPrice()
        {
            double sumAmount = 0;
            foreach (ItemOrdered item in _detailsPayments)
            {
                sumAmount += item.Amount;
            }
            return sumAmount;
        }
    }
}
