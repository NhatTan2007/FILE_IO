using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3_UPDATE.Services
{
    static class MenuProgramServices
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("PROGRAM MANAGEMENT COFFEE SHOP\n");
            Console.WriteLine("Please select an option\n");
            Console.WriteLine("1. Create more table");
            Console.WriteLine("2. Create item of menu");
            Console.WriteLine("3. Order");
            Console.WriteLine("4. Checkout payment");
            Console.WriteLine("5. List table free");
            Console.WriteLine("6. Exit");
        }

        public static void DisplayMenuCreateItem()
        {
            Console.WriteLine();
            Console.WriteLine("1. Create a drink");
            Console.WriteLine("2. Create a food");
            Console.WriteLine("3. Back");
        }
    }
}
