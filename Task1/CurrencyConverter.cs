using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class CurrencyConverter
    {
        public Currency ConvertTo(string curToConvert,Currency currency)
        {
            double amount = 0;
            string cur = string.Empty;
            if (curToConvert == "$")
            {
                if (currency.CurrencyName == "E")
                    return new Currency(amount * 0.8, "E");
                else
                    return new Currency(amount * 27, "grn");
            }
            else if (curToConvert == "E")
            {
                if (currency.CurrencyName == "$")
                    return new Currency(amount * 1.2, "$");
                else
                    return new Currency(amount * 30, "grn");
            }
            else
            {
                if (currency.CurrencyName == "E")
                    return new Currency(amount / 30, "E");
                else
                    return new Currency(amount / 27, "$");
            }
        }
    }
}
