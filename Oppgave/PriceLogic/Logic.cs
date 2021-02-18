using System;
using System.Collections.Generic;

namespace PriceLogic
{
    public class Logic
    {
        public static double ShopingCart(IList<Items> items)
        {
            double totalprice = 0;
            double itemprice=0;
            IList<Items> distinctItems = new List<Items>();

            List<string> uniques = new List<string>();
            foreach (Items  item in items)
            {
               if (!uniques.Contains(item.PLUCode)) uniques.Add(item.PLUCode);
            }
            Items newitem = new Items();
            int quantity = 0;
            bool found = false;
            //make unique list according to quantity
            foreach (string code in uniques)
            {
                quantity = 0;
                found = false;
                foreach (Items item_ in items)
                {
                    if(code== item_.PLUCode)
                    {
                        quantity = quantity + item_.Quantity;
                        newitem = item_;
                        found = true;
                    }

                }
                if (found)
                {
                    newitem.Quantity = quantity;
                    distinctItems.Add(newitem);
                    newitem = new Items();
                }
            }


            foreach(Items listitem in distinctItems)
            {
                if (listitem.PLUCode == "A")
                {
                    itemprice = GetPrice(listitem.PLUCode, listitem.Quantity);
                }

                else if(listitem.PLUCode=="B")
                {
                    itemprice = GetPrice(listitem.PLUCode ,listitem.Quantity) ;
                }
                else if (listitem.PLUCode == "C")
                {
                    itemprice = GetPrice(listitem.PLUCode, listitem.Quantity);
                }

                totalprice += itemprice;
            }
            totalprice = PriceRound(totalprice);
            return totalprice;
        }

        public static double PriceRound(double price)
        {
            return Math.Round(price);
        }

        public static double GetPrice(string code,int quantity)
        {
            double price = 0;

            if (code == "A")
            {
                price = 59.9;
                double itemprice = price;
                if (quantity < 3)
                {
                    price = itemprice * quantity;
                }
                else if (quantity == 3)
                {
                    price = itemprice * (quantity - 1);
                }
                else if (quantity > 2 && quantity != 3)
                {
                    int tempq = quantity / 3;
                    price = itemprice * (quantity - tempq);
                }
            }
            else if (code == "B")
            {
                double itemprice = 399;
                double offerprice = 333;
                if (quantity < 3)
                {
                    price = itemprice * quantity;
                }
                else if (quantity == 3 || quantity % 3 == 0)
                {
                    price = offerprice * quantity;
                }
                else if (quantity % 3 > 0)
                {
                    int temp = quantity / 3;
                    price = (temp * 3) * offerprice + (itemprice * (quantity - (temp * 3)));
                }
            }
            else if (code == "C")
            {
                price = 19.54 * quantity;
            }
            return price;
        }
    }
}
