using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace BAI_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int yourChoice = - 1;
            bool checkInput = false;
            //setup data
            string strPathFileData = @"D:\LEARNING\MODULE 2\14. FILE IO\EXERCISE\BAI TAP THEM\READ AND WRITE JSON\BAI 3\BAI 3\dataFiles";
            string strFileNameData = "data.json";
            string strPathFilePayment = @"D:\LEARNING\MODULE 2\14. FILE IO\EXERCISE\BAI TAP THEM\READ AND WRITE JSON\BAI 3\BAI 3\paymentFiles";
            string strFileNamePayment = string.Empty;
            string strPathFileOrder = @"D:\LEARNING\MODULE 2\14. FILE IO\EXERCISE\BAI TAP THEM\READ AND WRITE JSON\BAI 3\BAI 3\orderFiles";
            string strFileNameOrder = $"Order_{DateTime.UtcNow.ToString("dd.MM.yyyy")}.json";
            CoffeShop newShop = new CoffeShop();
            //DateTime today = new DateTime();
            if (File.Exists(@$"{strPathFileData}\{strFileNameData}"))
            {
                newShop = JsonConvert.DeserializeObject<CoffeShop>(ReadFileJson(strPathFileData, strFileNameData));
            }
            if (File.Exists(@$"{strPathFileOrder}\{strFileNameOrder}"))
            {
                newShop.OrderHistoryOfShop = JsonConvert.DeserializeObject<OrderHistory>(ReadFileJson(strPathFileOrder, strFileNameOrder));
            }
            while (true)
            {
                back_To_Menu:
                Menu();
                do
                {
                    Console.Write("Your option: ");
                    checkInput = TryParseInt(out yourChoice);
                } while (!checkInput || yourChoice < 0);
                switch (yourChoice)
                {
                    #region Add more tables
                    case 1:
                        int numberTableToCreate;
                        Console.WriteLine($"Shop now have {newShop.ListTables.Count} tables");
                        do
                        {
                            Console.Write("Please enter number of tables you want to add: ");
                            checkInput = TryParseInt(out numberTableToCreate);
                        } while (!checkInput || numberTableToCreate <0);
                        newShop.AddMoreTable(numberTableToCreate);
                        string dataToWrite = JsonConvert.SerializeObject(newShop, Formatting.Indented);
                        WriteFileJson(dataToWrite, strPathFileData, strFileNameData);
                        break;
                    #endregion
                    #region Add item of menu
                    case 2:
                        back_To_SubMenuItem:
                        subMenuItem();
                        do
                        {
                            Console.Write("Your Option: ");
                            checkInput = TryParseInt(out yourChoice);
                        } while (!checkInput || yourChoice <= 0 || yourChoice > 3);
                        if (yourChoice == 3) goto back_To_Menu;
                        string name = string.Empty;
                        double price;
                        string unit;
                        do
                        {
                            Console.Write("Please enter name of item: ");
                            name = FormatName(Console.ReadLine().Trim());
                        } while (name == "");

                        if (!newShop.Menu.IsItemExists(name))
                        {
                            do
                            {
                                Console.Write("Please enter item's price: ");
                                checkInput = double.TryParse(Console.ReadLine().Trim(), out price);
                            } while (!checkInput || price <= 0);
                            do
                            {
                                int temp;
                                Console.Write("Please enter unit type of item: ");
                                unit = Console.ReadLine().Trim();
                                checkInput = int.TryParse(unit, out temp);
                            } while (unit == "" || checkInput);
                            switch (yourChoice)
                            {
                                case 1:
                                    Drink newDrink = new Drink(nameInput: name, priceInput: price, unitInput: unit);
                                    newShop.Menu.ListDrinksOfShop.Add(newDrink);
                                    Console.WriteLine("Your drink item has add to Drinks Menu");
                                    break;
                                case 2:
                                    Food newFood = new Food(nameInput: name, priceInput: price, unitInput: unit);
                                    newShop.Menu.ListFoodsOfShop.Add(newFood);
                                    Console.WriteLine("Your food item has add to Foods Menu");
                                    break;
                            }
                            dataToWrite = JsonConvert.SerializeObject(newShop, Formatting.Indented);
                            WriteFileJson(dataToWrite, strPathFileData, strFileNameData);
                            string choice = string.Empty;
                            do
                            {
                                Console.Write("Do you want add more item? (Y/N): ");
                                choice = Console.ReadLine().Trim();
                            } while (choice != "Y" && choice !="N" && choice != "y" && choice != "n");
                            if (choice == "Y" || choice == "y") goto back_To_SubMenuItem;
                        } else 
                        {
                            Console.WriteLine($"Shop have item with name {name}, please change another name");
                            goto back_To_SubMenuItem;
                        }
                        break;
                    #endregion
                    #region Order
                    case 3:
                        if (newShop.ListTables.Count <= 0 || newShop.Menu.IsMenuEmpty())
                        {
                            Console.WriteLine("Shop have no table or menu is empty to order");
                            goto back_To_Menu;
                        }
                        else
                        {
                            Console.WriteLine(newShop.Menu.DisplayDrinksMenu());
                            Console.WriteLine(newShop.Menu.DisplayFoodsMenu());
                            int id;
                            int qty;
                            int tableNumber = 0;
                            Console.WriteLine("Enter 0 to cancel");
                            do
                            {
                                Console.Write("Please enter id of item: ");
                                checkInput = TryParseInt(out id);
                            } while (!checkInput || id > ItemsOfMenu._currentMaxId || id < 0 );
                            if (id == 0) goto back_To_Menu;     // back to menu
                            do
                            {
                                Console.Write($"Please enter number of item you want to order: ");
                                checkInput = TryParseInt(out qty);
                            } while (!checkInput || qty < 0);
                            if (id == 0) goto back_To_Menu;     // back to menu
                            do
                            {
                                Console.Write($"Please enter table you want to add: ");
                                checkInput = TryParseInt(out tableNumber);
                            } while (!checkInput || tableNumber < 0 || tableNumber > newShop.ListTables.Count);
                            if (id == 0) goto back_To_Menu;         //back to menu
                            ItemsOfMenu itemOrder = null;
                            Table tableOrder = null;
                            if (newShop.Menu.GetItemById(id) != null) itemOrder = newShop.Menu.GetItemById(id);
                            if (newShop.GetTableOrder(tableNumber) != null) tableOrder = newShop.GetTableOrder(tableNumber);
                            if (itemOrder != null && tableOrder != null)
                            {
                                newShop.OrderDrinksOrFoods(itemOrder, tableOrder, qty);
                                string orderToWrite = JsonConvert.SerializeObject(newShop.OrderHistoryOfShop, Formatting.Indented);
                                WriteFileJson(dataToWrite: orderToWrite, pathFile: strPathFileOrder, fileName: strFileNameOrder);
                                Console.Write("Your order has succeess");
                            }
                            else Console.WriteLine("Please check again your input");
                        }
                        break;
                    #endregion
                    #region Create Payments
                    case 4:
                        int tableNumberCheckout = -1;
                        Console.WriteLine("Enter 0 for back to main Program");
                        do
                        {
                            Console.Write("Please enter table number to create payment: ");
                            checkInput = TryParseInt(out tableNumberCheckout);
                        } while (!checkInput);
                        if (tableNumberCheckout == 0) goto back_To_Menu;
                        if (tableNumberCheckout > 0 && tableNumberCheckout <= newShop.ListTables.Count)
                        {
                            
                            int index = newShop.OrderHistoryOfShop.LastIndexOrderOfTable(tableNumberCheckout);
                            if (index != -1)
                            {
                                Order orderCheckout = newShop.OrderHistoryOfShop.ListOrders[index];
                                if (!orderCheckout.IsPaid)
                                {
                                    Payment newPayment = new Payment(orderCheckout);
                                    orderCheckout.DateTimeEndOrder = DateTime.UtcNow.ToString("g");
                                    orderCheckout.IsPaid = true;
                                    //write BILL
                                    dataToWrite = JsonConvert.SerializeObject(newShop.OrderHistoryOfShop, Formatting.Indented);
                                    strFileNamePayment = $"BILL_TABLENUMBER_{newPayment.TableNumber}_{DateTime.UtcNow.ToString("dd.MM.yyy.hh.mm.ss")}";
                                    WriteFileJson(dataToWrite, strPathFilePayment, strFileNamePayment);
                                    //update Order status just checkout;
                                    string orderToWrite = JsonConvert.SerializeObject(newShop.OrderHistoryOfShop, Formatting.Indented);
                                    WriteFileJson(dataToWrite: orderToWrite, pathFile: strPathFileOrder, fileName: strFileNameOrder);
                                }
                                else
                                {
                                    Console.WriteLine($"There are no order not paid of table number {tableNumberCheckout}");
                                }
                            } else
                            {
                                Console.WriteLine($"There are no order of table number {tableNumberCheckout}");
                            }

                        }
                        else Console.WriteLine("Invalid table number");

                        break;
                    #endregion
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }


         }

        static void Menu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("PROGRAM MANAGEMENT COFFEE SHOP\n");
            Console.WriteLine("Please select an option\n");
            Console.WriteLine("1. Create more table");
            Console.WriteLine("2. Create item of menu");
            Console.WriteLine("3. Order");
            Console.WriteLine("4. Checkout Payment");
            //Console.WriteLine("5. Display array");
            Console.WriteLine("0. Exit");
        }

        static void subMenuItem()
        {
            Console.WriteLine();
            Console.WriteLine("1. Create a drink");
            Console.WriteLine("2. Create a food");
            Console.WriteLine("3. Back to main Program");
        }

        static string FormatName(string nameInput)
        {
            //Remove space;
            while (nameInput.IndexOf("  ") != -1)
            {
                nameInput = nameInput.Replace("  ", " ");
            }
            //make Upercase first char each word.
            nameInput = nameInput.ToLower();
            string[] nameSplitArray = nameInput.Split(" ");
            for (int i = 0; i < nameSplitArray.Length; i++)
            {
                char[] stringSplitToChar = nameSplitArray[i].ToCharArray();
                stringSplitToChar[0] = Char.ToUpper(stringSplitToChar[0]);
                nameSplitArray[i] = new string(stringSplitToChar);
            }
            nameInput = String.Join(" ", nameSplitArray);
            return nameInput;
        }

        static void WriteFileJson(string dataToWrite, string pathFile, string fileName, bool append = false)
        {
            using (StreamWriter sr = new StreamWriter(@$"{pathFile}\{fileName}", append, new UTF8Encoding()))
            {
                sr.WriteLine(dataToWrite);
            }
        }

        static string ReadFileJson(string pathFile, string fileName)
        {
            string data = string.Empty;
            using (StreamReader sr = new StreamReader(@$"{pathFile}\{fileName}", new UTF8Encoding()))
            {
                data = sr.ReadToEnd();
            }
            return data;
        }

        static bool TryParseInt(out int number)
        {
            return int.TryParse(Console.ReadLine().Trim(), out number);
        }

    }
}
