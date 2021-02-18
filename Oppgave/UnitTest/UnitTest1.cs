using NUnit.Framework;
using PriceLogic;
using System.Collections.Generic;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void PriceRound1()
        {
            double itemprice = 59.9;
            double price = Logic.PriceRound(itemprice);
            Assert.AreEqual(60, price);
        }
        [Test]
        public void PriceRound2()
        {
            double itemprice = 49.1;
            double price = Logic.PriceRound(itemprice);
            Assert.AreEqual(49, price);
        }
        [Test]
        public void PriceRound3()
        {
            double itemprice = 39.5;
            double price = Logic.PriceRound(itemprice);
            Assert.AreEqual(40, price);
        }
        [Test]
        public void PriceRound4()
        {
            double itemprice = 39.4;
            double price = Logic.PriceRound(itemprice);
            Assert.AreEqual(39, price);
        }

        [Test]
        public void ByOneItemAReturnPrice()
        {
            //item price  59,90

            IList<Items> items = new List<Items>();
            

            Items item = new Items();
            item.PLUCode = "A";
            item.Quantity = 1;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);

            
            Assert.AreEqual(60, totalprice);
            Assert.Pass();
        }
        [Test]
        public void ByTwoItemAGetOneFree()
        {
            //item price  59,90
            IList<Items> items = new List<Items>();
            

            Items item = new Items();
            item.PLUCode = "A";
            item.Quantity = 2;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);

            
            Assert.AreEqual(120, totalprice);
            Assert.Pass();
        }
        [Test]
        public void ByTwoItemAGetOneFree_2()
        {
            //item price  59,90
            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "A";
            item.Quantity = 1;

            items.Add(item);

            item = new Items();
            item.PLUCode = "A";
            item.Quantity = 1;
            items.Add(item);


            double totalprice = Logic.ShopingCart(items);

            Assert.AreEqual(120, totalprice);
            Assert.Pass();
        }
        [Test]
        public void ByThreeItemAGetOneFree_3()
        {
            //item price  59,90

            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "A";
            item.Quantity = 1;

            items.Add(item);

            item = new Items();
            item.PLUCode = "A";
            item.Quantity = 1;

            items.Add(item);


            item = new Items();
            item.PLUCode = "A";
            item.Quantity = 1;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);

            Assert.AreEqual(120, totalprice);
            
        }

        [Test]
        public void By4ItemAGetOneFree()
        {
            
            IList<Items> items = new List<Items>();
            

            Items item = new Items();
            item.PLUCode = "A";
            item.Quantity = 3;

            items.Add(item);

            item = new Items();
            item.PLUCode = "A";
            item.Quantity = 1;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);

            
            Assert.AreEqual(180, totalprice);

        }
        [Test]
        public void By11ItemAGetThreeFree()
        {
            
            IList<Items> items = new List<Items>();
            

            Items item = new Items();
            item.PLUCode = "A";
            item.Quantity = 8;

            items.Add(item);

            item = new Items();
            item.PLUCode = "A";
            item.Quantity = 1;

            items.Add(item);
            item = new Items();
            item.PLUCode = "A";
            item.Quantity = 1;

            items.Add(item);
            item = new Items();
            item.PLUCode = "A";
            item.Quantity = 1;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);

            
            Assert.AreEqual(479, totalprice);

        }

        [Test]
        public void ByItemAGetRespectiveFreeXX(
            [Values(12,3,4,5,6,7,8,9,13,14,15,16,17,18,19,20)] int quantity)
        {

            IList<Items> items = new List<Items>();


            Items item = new Items();
            item.PLUCode = "A";
            item.Quantity = quantity;

            items.Add(item);



            double totalprice = Logic.ShopingCart(items);


            double itemprice = Logic.PriceRound(Logic.GetPrice("A", quantity));
            Assert.AreEqual(itemprice, totalprice);
            

        }

        [Test]
        public void BuyItemB()
        {

            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "B";
            item.Quantity = 1;

            items.Add(item);

            

            double totalprice = Logic.ShopingCart(items);

            Assert.AreEqual(399, totalprice);

        }
        [Test]
        public void BuyItemBx2()
        {

            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "B";
            item.Quantity = 1;

            items.Add(item);
            item = new Items();
            item.PLUCode = "B";
            item.Quantity = 1;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);

            Assert.AreEqual(798, totalprice);

        }
        //this is extra test 
        [Test]
        public void BuyItemBxx([Values(1, 2, 3, 4, 5, 6, 7, 8, 10)] int quantity)
        {

            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "B";
            item.Quantity = quantity;

            items.Add(item);
            double totalprice = Logic.ShopingCart(items);
            double itemprice = Logic.GetPrice("B", quantity);
            Assert.AreEqual(Logic.PriceRound(itemprice), totalprice);

        }
        [Test]
        public void BuyItemBx3()
        {

            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "B";
            item.Quantity = 3;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);

            Assert.AreEqual(999, totalprice);

        }

        [Test]
        public void BuyItemBx4()
        {

            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "B";
            item.Quantity = 4;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);

            Assert.AreEqual(1398, totalprice);

        }
        [Test]
        public void BuyItemBx5()
        {

            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "B";
            item.Quantity = 5;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);

            Assert.AreEqual(1797, totalprice);

        }
        [Test]
        public void BuyItemBx6()
        {

            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "B";
            item.Quantity = 6;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);

            Assert.AreEqual(1998, totalprice);

        }
        [Test]
        public void BuyItemBxxx([Values(25)] int quantity)
        {

            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "B";
            item.Quantity = quantity;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);

            double price = Logic.PriceRound(Logic.GetPrice("B", quantity));
            Assert.AreEqual(8391, totalprice);

        }
        [Test]
        public void BuyItemBx7()
        {

            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "B";
            item.Quantity = 7;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);

            double price = Logic.PriceRound(Logic.GetPrice("B", 7));
            Assert.AreEqual(2397, totalprice);

        }
        [Test]
        public void BuyItemBx8()
        {

            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "B";
            item.Quantity = 8;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);

            double price = Logic.PriceRound(Logic.GetPrice("B", 8));
            Assert.AreEqual(2796, totalprice);

        }
        [Test]
        public void BuyItemCx1()
        {
            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "C";
            item.Quantity = 1;

            items.Add(item);



            double totalprice = Logic.ShopingCart(items);

            Assert.AreEqual(20, totalprice);
        }
        [Test]
        public void BuyItemCX2a()
        {
            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "C";
            item.Quantity = 1;

            items.Add(item);
            item = new Items();
            item.PLUCode = "C";
            item.Quantity = 1;

            items.Add(item);



            double totalprice = Logic.ShopingCart(items);

            Assert.AreEqual(39, totalprice);
        }
        [Test]
        public void BuyItemCx5()
        {
            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "C";
            item.Quantity = 5;

            items.Add(item);



            double totalprice = Logic.ShopingCart(items);

            Assert.AreEqual(98, totalprice);
        }
        [Test]
        public void BuyItemCx([Values(1,2,3,4,5,6,7,8,9,10)] int quantity)
        {
            IList<Items> items = new List<Items>();

            Items item = new Items();
            item.PLUCode = "C";
            item.Quantity = quantity;

            items.Add(item);

            double totalprice = Logic.ShopingCart(items);
            double itemprice = Logic.PriceRound(Logic.GetPrice("C", quantity));

            Assert.AreEqual(itemprice, totalprice);
        }


        [Test]
        public void Buy4AllItemsItem()
        {
            IList<Items> items = new List<Items>();

            int quantity = 4;

            Items item = new Items();
            item.PLUCode = "C";
            item.Quantity = quantity;
            items.Add(item); //78.16

            item = new Items();
            item.PLUCode = "A";
            item.Quantity = quantity;
            items.Add(item);//179.7

            item = new Items();
            item.PLUCode = "B";
            item.Quantity = quantity;
            items.Add(item);//1398

            double totalprice = Logic.ShopingCart(items);
            double itemprice =1656 ;

            Assert.AreEqual(itemprice, totalprice);
        }




    }
}