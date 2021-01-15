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

        public Table GetTable (int tableNumber)
        {
            foreach (Table item in _listTable)
            {
                if (item.TableNumber == tableNumber) return item;
            }
            return null;
        }

        private string ToStringListTables(List<Table> listTables)
        {
            string result = string.Empty;
            int count = 0;
            foreach (Table table in listTables)
            {
                result += $"{++count}. Table {table.TableNumber}\n";
            }
            return result;
        }

        public void ShowTablesFree()
        {
            List<Table> listTablesFree = new List<Table>();
            foreach (Table table in _listTable)
            {
                if (!table.IsUsed) listTablesFree.Add(table);
            }
            Console.WriteLine("These tables are free:");
            Console.WriteLine(ToStringListTables(listTablesFree));
        }

        public void ChangeTableStatus(Table inputTable)
        {
            if (inputTable.IsUsed) inputTable.IsUsed = false;
            else inputTable.IsUsed = true;
            FileJsonServices.WriteFileJson(_shopHasTableServices, FilePath.StrDataFileFullPath);
        }
    }
}
