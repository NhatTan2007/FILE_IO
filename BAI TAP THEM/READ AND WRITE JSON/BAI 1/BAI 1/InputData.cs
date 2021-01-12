using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_1
{
    class InputData<T> where T: class
    {
        public List<T> GroupOfNumbers { get; set; }
    }

}
