using System;
using System.Collections.Generic;
using System.Text;

namespace PriceLogic
{
    public class PLUC
    {
        public string kode { get; set; }
        public double price { get; set; }
        public string Name { get; set; }
        public PLUC()
        {
            this.Name = "Talkum ";
            this.kode = "PLUC";
            this.price = 19.54;
        }
    }
}
