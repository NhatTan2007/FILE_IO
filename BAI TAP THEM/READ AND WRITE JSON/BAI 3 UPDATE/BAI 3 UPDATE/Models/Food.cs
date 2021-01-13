using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3_UPDATE.Models
{
    class Food : ItemOfMenu
    {
        public Food(string nameInput, double priceInput, string unitInput) : base(name: nameInput, price: priceInput, unit: unitInput)
        {

        }
    }
}
