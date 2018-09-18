using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;
using System.IO;


namespace Task1Tests
{
    [TestClass]
    public class CurrencyTest
    {
        [TestMethod]
        public void CurrencyConstructorTest()
        {
            Currency cur = new Currency(3.5, CurrencyName.Dollar);

            Assert.IsTrue(cur.Amount == 3.5 && cur.CurrName == CurrencyName.Dollar);
        }
        [TestMethod]
        public void CurrencyReadMethodTest()
        {
            StreamReader sr = File.OpenText(@"C:\GitHub\SBTDD\TestFile.txt");
            Currency cur = new Currency();

            cur.Read(sr);

            Assert.IsTrue(cur.Amount == 212 && cur.CurrName == CurrencyName.Grivna);
        }
        [TestMethod]
        public void CurrencyToStringTest()
        {
            Currency cur = new Currency(10, CurrencyName.Euro);

            Assert.AreEqual(cur.ToString(), "Currency: Euro;Amount: 10");
        }
    }
}
