using NUnit.Framework;
using PriceLogic;
using System;
using System.Collections.Generic;


namespace TestModel
{
    [TestFixture]
    public class LogicTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.Pass();
        }
        [Test]
        public void ByOneAReturnPrice()
        {
            //Arrange
            IList<Items> items = new List<Items>();
            //act
            
            Items item = new Items();
            item.PLUCode = "PLUA";
            item.Quantity = 1;

            items.Add(item);

            Double totalprice = Logic.ShopingCart(items);

            //Assert
            Assert.AreEqual(59.9, totalprice);
        }
    }
}
