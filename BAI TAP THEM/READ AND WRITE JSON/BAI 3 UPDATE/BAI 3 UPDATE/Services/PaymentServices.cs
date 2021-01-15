using BAI_3_UPDATE.Models;
using BAI_3_UPDATE.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BAI_3_UPDATE.Services
{
    class PaymentServices
    {
        private Shop _myShop;
        private OrderServices _orderServices;
        public PaymentServices(ref Shop inputShop)
        {
            _myShop = inputShop;
            _orderServices = new OrderServices(ref _myShop);
        }
        public void CreateBill(int tableNumberCheckout)
        {
            if (tableNumberCheckout > 0 && tableNumberCheckout <= _myShop.ListTables.Count)
            {
                int index = _orderServices.LastIndexOrderOfTable(tableNumberCheckout);
                if (index != -1)
                {
                    Order orderCheckout = _myShop.OrderHistoryOfShop.ListOrders[index];
                    if (!orderCheckout.IsPaid)
                    {
                        Payment newPayment = new Payment(orderCheckout);
                        orderCheckout.DateTimeEndOrder = DateTime.UtcNow.ToString("g");
                        orderCheckout.IsPaid = true;
                        //write BILL
                        if (!Directory.Exists(FilePath.StrPaymentFolderPath)) Directory.CreateDirectory(FilePath.StrPaymentFolderPath);
                        FilePath.StrPaymentFileName = $"BILL_TABLENUMBER_{newPayment.TableNumber}_{DateTime.UtcNow.ToString("dd.MM.yyy.hh.mm.ss")}";
                        FileJsonServices.WriteFileJson(newPayment, FilePath.StrPaymentFileFullPath);
                        //update Order status just checkout
                        FileJsonServices.WriteFileJson(_myShop.OrderHistoryOfShop, FilePath.StrOrderHistoryFileFullPath);

                    }
                    else Console.WriteLine($"There are no order not paid of table number {tableNumberCheckout}");
                }
                else Console.WriteLine($"There are no order of table number {tableNumberCheckout}");
            }
            else Console.WriteLine("Invalid table number");
        }
    }
}
