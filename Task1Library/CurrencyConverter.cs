using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    /// <summary>
    /// CurrencyConverter клас містить методи конвертації валют
    /// </summary>
    public static class CurrencyConverter
    {
        /// <summary>
        /// Сумує список різних валют в одну валюту
        /// </summary>
        /// <param name="currName">Назва валюти</param>
        /// <param name="list">Список валют</param>
        /// <returns>Повертає суму всіх валют в одній валюті</returns>
        public static Currency ConvertTo2(CurrencyName currName, List<Currency> list)
        {
            double sumOfAll = default(double);
            list.Sort((Currency a1, Currency a2) =>
            {
                return a1.CurrName.CompareTo(a2.CurrName);
            });
            if (currName == CurrencyName.Grivna)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].CurrName == currName)
                        sumOfAll += list[i].Amount;
                    else if (list[i].CurrName == CurrencyName.Dollar)
                    {
                        sumOfAll += list[i].Amount * 27;
                    }
                    else
                    {
                        sumOfAll += list[i].Amount * 30;
                    }
                }
            }
            else if (currName == CurrencyName.Dollar)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].CurrName == currName)
                        sumOfAll += list[i].Amount;
                    else if (list[i].CurrName == CurrencyName.Grivna)
                    {
                        sumOfAll += list[i].Amount / 27;
                    }
                    else
                    {
                        sumOfAll += list[i].Amount * 1.2;
                    }
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].CurrName == currName)
                        sumOfAll += list[i].Amount;
                    else if (list[i].CurrName == CurrencyName.Dollar)
                    {
                        sumOfAll += list[i].Amount * 0.8;
                    }
                    else
                    {
                        sumOfAll += list[i].Amount / 30;
                    }
                }
            }
            return new Currency(sumOfAll, currName);
        }
        /// <summary>
        /// Конвертує валюту в бажану валюту
        /// </summary>
        /// <param name="currName">Назва валюти на яку ми хочемо конвертувати</param>
        /// <param name="currency">Конвертована валюта</param>
        /// <returns>Повертає конвертовану валюту</returns>
        public static Currency ConvertTo(CurrencyName currName, Currency currency)
        {
            double amount = currency.Amount;
            if (currName == currency.CurrName)
            {
                return new Currency(currency.Amount,currency.CurrName);
            }
            else if (currName == CurrencyName.Dollar)
            {
                if (currency.CurrName == CurrencyName.Euro)
                    return new Currency(amount * 1.2, CurrencyName.Dollar);
                else
                    return new Currency(amount / 27, CurrencyName.Dollar);
            }
            else if (currName == CurrencyName.Grivna)
            {
                if (currency.CurrName == CurrencyName.Dollar)
                    return new Currency(amount * 27, CurrencyName.Grivna);
                else
                    return new Currency(amount * 30, CurrencyName.Grivna);
            }
            else
            {
                if (currency.CurrName == CurrencyName.Dollar)
                    return new Currency(amount * 0.8, CurrencyName.Euro);
                else
                    return new Currency(amount / 30, CurrencyName.Euro);
            }
        }
    }
}
