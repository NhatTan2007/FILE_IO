using System;
using System.Text;
using BAI_3_UPDATE.Services;
using BAI_3_UPDATE.Models;

namespace BAI_3_UPDATE
{
    class Program
    {
        static void Main(string[] args)
        {
            int yourChoice = 0;
            bool checkInput;
            Shop coffeShop = new Shop();
            SetupDataServices.SetupData(ref coffeShop);
            MenuShopServices menuServicesShop = new MenuShopServices(ref coffeShop);
            OrderServices orderServicesShop = new OrderServices(ref coffeShop);
            TableServices tableServicesShop = new TableServices(ref coffeShop);

            while (true)
            {
            backToMainMenu:
                MenuProgramServices.DisplayMainMenu();
                do
                {
                    Console.Write("Your option: ");
                    checkInput = ConvertServices.ToIntByTryParse(Console.ReadLine(), out yourChoice);
                } while (!checkInput || yourChoice <= 0 || yourChoice > 5);
                switch (yourChoice)
                {
                    #region Add more tables
                    case 1:
                        int numberTableToCreate;
                        Console.WriteLine($"Shop now have {coffeShop.ListTables.Count} tables (maximum is 50)");
                        do
                        {
                            Console.Write("Please enter number of tables you want to add(max 20): ");
                            checkInput = ConvertServices.ToIntByTryParse(Console.ReadLine(), out numberTableToCreate);
                        } while (!checkInput || numberTableToCreate < 0 || numberTableToCreate > 20);
                        if (numberTableToCreate + coffeShop.ListTables.Count > 50)
                        {
                            Console.WriteLine("Your shop can't have to much tables");
                            goto backToMainMenu; //Back to main menu
                        }
                        tableServicesShop.AddMoreTable(numberTableToCreate);
                        FileJsonServices.WriteFileJson(coffeShop, FilePath.StrDataFileFullPath);
                        break;
                    #endregion
                    #region Add Item to Menu of Shop
                    case 2:
                    backToMenuAddItem:
                        MenuProgramServices.DisplayMenuCreateItem();
                        do
                        {
                            Console.Write("Your Option: ");
                            checkInput = ConvertServices.ToIntByTryParse(Console.ReadLine(), out yourChoice);
                        } while (!checkInput || yourChoice <= 0 || yourChoice > 3);
                        if (yourChoice == 3) goto backToMenuAddItem;
                        menuServicesShop.AddItemToMenuShop();
                        string choiceContinue = string.Empty;
                        do
                        {
                            Console.Write("Do you want add more item? (Y/N): ");
                            choiceContinue = Console.ReadLine().Trim();
                        } while (choiceContinue != "Y" && choiceContinue != "N" && choiceContinue != "y" && choiceContinue != "n");
                        if (choiceContinue == "Y" || choiceContinue == "y") goto backToMainMenu;
                        break;
                    #endregion
                    #region Order
                    case 3:
                        if (orderServicesShop.CanMakeOrder())
                        {
                            Console.WriteLine("Shop have no table or menu is empty to order");
                            goto backToMainMenu;
                        }
                        else
                        {
                            Console.WriteLine(menuServicesShop.DisplayDrinksMenu());
                            Console.WriteLine(menuServicesShop.DisplayFoodsMenu());
                            int id, qty, tableNumber;
                            if (!orderServicesShop.InputDataOrder(out id, out qty, out tableNumber)) goto backToMainMenu;
                            ItemOfMenu itemOrder = null;
                            Table tableOrder = null;
                            if (menuServicesShop.GetItemById(id) != null) itemOrder = menuServicesShop.GetItemById(id);
                            if (tableServicesShop.GetOrderTable(tableNumber) != null) tableOrder = tableServicesShop.GetOrderTable(tableNumber);
                            if (itemOrder != null && tableOrder != null)
                            {
                                orderServicesShop.OrderDrinksOrFoods(itemOrder, tableOrder, qty);
                                FileJsonServices.WriteFileJson(coffeShop.OrderHistoryOfShop, FilePath.StrOrderHistoryFileFullPath);
                                Console.Write("Your order has success\n");
                            }
                            else Console.WriteLine("Please check again your input");
                        }
                        break;
                    #endregion
                    #region Create Payment
                    case 4:
                        int tableNumberCheckout = -1;
                        Console.WriteLine("Enter 0 for back to main Program");
                        do
                        {
                            Console.Write("Please enter table number to create payment: ");
                            checkInput = ConvertServices.ToIntByTryParse(Console.ReadLine(), out tableNumberCheckout);
                        } while (!checkInput);
                        if (tableNumberCheckout == 0) goto backToMainMenu;
                        if(tableNumberCheckout > 0 && tableNumberCheckout <= coffeShop.ListTables.Count)
                        {
                            int index = orderServicesShop.LastIndexOrderOfTable(tableNumberCheckout);
                            if (index != -1)
                            {
                                Order orderCheckout = coffeShop.OrderHistoryOfShop.ListOrders[index];
                                if (!orderCheckout.IsPaid)
                                {
                                    Payment newPayment = new Payment(orderCheckout);
                                    orderCheckout.DateTimeEndOrder = DateTime.UtcNow.ToString("g");
                                    orderCheckout.IsPaid = true;
                                    //write BILL
                                    FilePath.StrPaymentFileName = $"BILL_TABLENUMBER_{newPayment.TableNumber}_{DateTime.UtcNow.ToString("dd.MM.yyy.hh.mm.ss")}";
                                    FileJsonServices.WriteFileJson(newPayment, FilePath.StrPaymentFileFullPath);
                                    //update Order status just checkout
                                    FileJsonServices.WriteFileJson(coffeShop.OrderHistoryOfShop, FilePath.StrOrderHistoryFileFullPath);

                                } else Console.WriteLine($"There are no order not paid of table number {tableNumberCheckout}");
                            } else Console.WriteLine($"There are no order of table number {tableNumberCheckout}");
                        } else Console.WriteLine("Invalid table number");
                        break;
                    #endregion
                    case 5:
                        Environment.Exit(0);
                        break;
                }

            }
        }
    }
}