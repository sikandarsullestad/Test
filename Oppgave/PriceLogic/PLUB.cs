using System;
using System.Collections.Generic;
using System.Text;

namespace PriceLogic
{
    public class PLUB
    {
        public string kode { get; set; }
        public double price { get; set; }
        public string Name { get; set; }
        public PLUB()
        {
            this.Name = "Stetoskop";
            this.kode = "PLUB";
            this.price = 399;
        }
    }
}
