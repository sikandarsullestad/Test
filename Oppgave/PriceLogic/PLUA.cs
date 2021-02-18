using System;
using System.Collections.Generic;
using System.Text;

namespace PriceLogic
{
    public class PLUA
    {
        public string kode { get; set; }
        public double price { get; set; }
        public string Name { get; set; }
         public PLUA()
        {
            this.Name = "Gummihansker (selges i par)";
            this.kode = "PLUA";
            this.price = 59.90;
        }
    }
}
