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
            ShopServices coffeShopServices = new ShopServices(ref coffeShop);

            while (true)
            {
            backToMainMenu:
                MenuProgramServices.DisplayMainMenu();
                do
                {
                    Console.Write("Your option: ");
                    checkInput = ConvertServices.ToIntByTryParse(Console.ReadLine(), out yourChoice);
                } while (!checkInput || yourChoice <= 0 || yourChoice > 6);
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
                        coffeShopServices.AddMoreTable(numberTableToCreate);
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
                        coffeShopServices.AddItemToMenuShop();
                        string choiceContinue = string.Empty;
                        do
                        {
                            Console.Write("Do you want add more item? (Y/N): ");
                            choiceContinue = Console.ReadLine().Trim();
                        } while (choiceContinue != "Y" && choiceContinue != "y" && choiceContinue != "Y" && choiceContinue != "n");
                        if (choiceContinue == "Y" || choiceContinue == "y") goto backToMenuAddItem;
                        break;
                    #endregion
                    #region Order
                    case 3:
                        if (coffeShopServices.CanMakeOrder())
                        {
                            Console.WriteLine("Shop have no table or menu is empty to order");
                            goto backToMainMenu;
                        }
                        else
                        {
                            coffeShopServices.DisplayProductsMenu();
                            int id, qty, tableNumber;
                            if (!coffeShopServices.InputDataOrder(out id, out qty, out tableNumber)) goto backToMainMenu;
                            ItemOfMenu itemOrder = null;
                            Table tableOrder = null;
                            if (coffeShopServices.GetItemById(id) != null) itemOrder = coffeShopServices.GetItemById(id);
                            if (coffeShopServices.GetTable(tableNumber) != null) tableOrder = coffeShopServices.GetTable(tableNumber);
                            if (itemOrder != null && tableOrder != null)
                            {
                                coffeShopServices.OrderDrinksOrFoods(itemOrder, tableOrder, qty);
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
                        coffeShopServices.CreateBill(tableNumberCheckout);
                        coffeShopServices.ChangeTableStatus(tableNumberCheckout);
                        break;
                    #endregion
                    case 5:
                        coffeShopServices.ShowTablesFree();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }

            }
        }
    }
}