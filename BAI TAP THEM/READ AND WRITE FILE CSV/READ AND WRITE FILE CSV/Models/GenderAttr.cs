using System;
using System.Collections.Generic;
using System.Text;

namespace READ_AND_WRITE_FILE_CSV.Models
{
    class GenderAttr : Attribute
    {
        public int value { get; set; }
        public GenderAttr(int value)
        {
            this.value = value;
        }
    }
}
