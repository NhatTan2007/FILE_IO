using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3
{
    class ListOfDrinks
    {
        private List<Drink> _listCoffee;
        private List<Drink> _listHotDrink;
        private List<Drink> _listFruitJiuce;
        private List<Drink> _listcoldBlended;

        internal List<Drink> ListCoffee { get => _listCoffee; set => _listCoffee = value; }
        internal List<Drink> ListHotDrink { get => _listHotDrink; set => _listHotDrink = value; }
        internal List<Drink> ListFruitJiuce { get => _listFruitJiuce; set => _listFruitJiuce = value; }
        internal List<Drink> ListcoldBlended { get => _listcoldBlended; set => _listcoldBlended = value; }
    }
}
