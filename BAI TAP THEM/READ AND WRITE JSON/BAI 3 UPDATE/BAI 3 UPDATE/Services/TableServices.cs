using System;
using System.Collections.Generic;
using System.Text;
using BAI_3_UPDATE.Models;
using BAI_3_UPDATE.Services;

namespace BAI_3_UPDATE.Services
{
    class TableServices
    {
        private Shop _shopHasTableServices;
        private List<Table> _listTable;
        public TableServices(ref Shop inputShop)
        {
            _shopHasTableServices = inputShop;
            _listTable = _shopHasTableServices.ListTables;
        }
        public void AddMoreTable(int numberTablesToAdd)
        {
            for (int i = 0; i < numberTablesToAdd; i++)
            {
                _listTable.Add(new Table());
            }
        }

        public Table GetOrderTable (int tableNumber)
        {
            foreach (Table item in _listTable)
            {
                if (item.TableNumber == tableNumber) return item;
            }
            return null;
        }
    }
}
