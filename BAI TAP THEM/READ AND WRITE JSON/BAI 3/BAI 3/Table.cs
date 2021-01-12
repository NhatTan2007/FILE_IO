﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3
{
    class Table
    {
        public static int _currentMaxTableNumber = 0;
        private int _tableNumber;
        public int TableNumber { get => _tableNumber;}

        public Table()
        {
            _tableNumber = ++_currentMaxTableNumber;
        }

        public static void SetCurrentMaxTableNumber(int currentMaxTableNumber)
        {
            _currentMaxTableNumber = currentMaxTableNumber;
        }
    }
}
