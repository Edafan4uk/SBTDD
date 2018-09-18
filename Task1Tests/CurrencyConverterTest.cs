using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;
using System.Collections.Generic;


namespace Task1Tests
{
    [TestClass]
    public class CurrencyConverterTest
    {
        [TestMethod]
        public void CurrencyConverterConvertTo2Test()
        {
            List<Currency> list = new List<Currency>();
            list.Add(new Currency(3, CurrencyName.Dollar));
            list.Add(new Currency(4, CurrencyName.Euro));
            list.Add(new Currency(7, CurrencyName.Dollar));
            list.Add(new Currency(1, CurrencyName.Grivna));
            list.Add(new Currency(2, CurrencyName.Dollar));

            Currency cur = CurrencyConverter.ConvertTo2(CurrencyName.Grivna,list);

            Assert.IsTrue(cur.Amount == 3 * 27 + 4 * 30 + 7 * 27 + 1 + 2 * 27 && cur.CurrName == CurrencyName.Grivna);
        }
        [TestMethod]
        public void CurrencyConverterConvertToTest()
        {
            Currency cur = new Currency(54, CurrencyName.Grivna);

            cur = CurrencyConverter.ConvertTo(CurrencyName.Dollar, cur);

            Assert.IsTrue(cur.Amount == 2 && cur.CurrName == CurrencyName.Dollar);
        }
    }
}
