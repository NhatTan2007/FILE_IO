using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3_UPDATE.Models
{
    class Drink : ItemOfMenu
    {
        public Drink(string nameInput, double priceInput, string unitInput) : base(name: nameInput, price: priceInput, unit: unitInput)
        {

        }
    }
}
