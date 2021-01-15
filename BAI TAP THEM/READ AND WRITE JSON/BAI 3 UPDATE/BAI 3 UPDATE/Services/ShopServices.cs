using BAI_3_UPDATE.Models;
using BAI_3_UPDATE.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3_UPDATE.Services
{
    class ShopServices
    {
        private Shop _myShop;
        private MenuShopServices _menuServicesShop;
        private OrderServices _orderServicesShop;
        private TableServices _tableServicesShop;
        private PaymentServices _paymentServicesShop;
        public ShopServices(ref Shop inputShop)
        {
            inputShop = SetupDataServices.SetupData();
            _myShop = inputShop;
            _menuServicesShop = new MenuShopServices(ref inputShop);
            _orderServicesShop = new OrderServices(ref inputShop);
            _tableServicesShop = new TableServices(ref inputShop);
            _paymentServicesShop = new PaymentServices(ref inputShop);
        }

        public void AddMoreTable(int number)
        {
            _tableServicesShop.AddMoreTable(number);
            FileJsonServices.WriteFileJson(_myShop, FilePath.StrDataFileFullPath);
        }
        public Table GetTable(int tableNumber)
        {
            return _tableServicesShop.GetTable(tableNumber);
        }

        public bool CanMakeOrder()
        {
            return _orderServicesShop.CanMakeOrder();
        }

        public void OrderDrinksOrFoods(ItemOfMenu itemOrder, Table tableOrder, int numberUnit = 1)
        {
            if (!tableOrder.IsUsed) _tableServicesShop.ChangeTableStatus(tableOrder);
            _orderServicesShop.OrderDrinksOrFoods(itemOrder, tableOrder, numberUnit);
            FileJsonServices.WriteFileJson(_myShop.OrderHistoryOfShop, FilePath.StrOrderHistoryFileFullPath);
        }

        public bool InputDataOrder(out int id, out int qty, out int tableNumber)
        {
            return _orderServicesShop.InputDataOrder(out id, out qty, out tableNumber);
        }

        public int LastIndexOrderOfTable(int tableNumberCheckout)
        {
            return _orderServicesShop.LastIndexOrderOfTable(tableNumberCheckout);
        }

        public void AddItemToMenuShop()
        {
            _menuServicesShop.AddItemToMenuShop();
        }

        public void DisplayProductsMenu()
        {
            _menuServicesShop.DisplayProductsMenu();
        }

        public ItemOfMenu GetItemById(int id)
        {
            return _menuServicesShop.GetItemById(id);
        }

        public void ShowTablesFree()
        {
            _tableServicesShop.ShowTablesFree();
        }
        public void CreateBill(int tableNumberCheckout)
        {
            _paymentServicesShop.CreateBill(tableNumberCheckout);
        }

        public void ChangeTableStatus(int tableNumber)
        {
            _tableServicesShop.ChangeTableStatus(_tableServicesShop.GetTable(tableNumber));
        }
    }
}
