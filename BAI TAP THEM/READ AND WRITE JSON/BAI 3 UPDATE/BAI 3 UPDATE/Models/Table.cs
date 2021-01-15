using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3_UPDATE.Models
{
    class Table
    {
        public static int _currentMaxTableNumber = 0;
        private int _tableNumber;
        private bool _isUsed;
        public int TableNumber { get => _tableNumber; }
        public bool IsUsed { get => _isUsed; set => _isUsed = value; }

        public Table()
        {
            _tableNumber = ++_currentMaxTableNumber;
            IsUsed = false;
        }
    }
}
