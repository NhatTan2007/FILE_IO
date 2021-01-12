using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3
{
    class Food : ItemsOfMenu
    {
        public Food(string nameInput, double priceInput, string unitInput) : base(name: nameInput, price: priceInput, unit: unitInput)
        {

        }
    }
}
