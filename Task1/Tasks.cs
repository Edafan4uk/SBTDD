using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    internal static class Tasks
    {
        private static List<Currency> currencies;
        private static List<Currency> totAmount;
        internal static void ReadFromFile(string path)
        {
            try
            {
                List<Currency> list = new List<Currency>();
                if (!File.Exists(@path))
                    throw new FileNotFoundException();
                using (StreamReader sr = File.OpenText(@path))
                {
                    Currency tempCurr;
                    while(!sr.EndOfStream)
                    {
                        tempCurr = new Currency();
                        tempCurr.Read(sr);
                        if(!tempCurr.HasMissingField)
                            list.Add(tempCurr);
                    }
                }
                currencies = list;
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        internal static void PrintOnlyGrn()
        {
            if (currencies != null)
            {
                var onlyGrn = from a in currencies where a.CurrName == CurrencyName.Grivna select a;
                foreach (var item in onlyGrn)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                ReadFromFile();
                PrintOnlyGrn();
            }
        }
        internal static void PrintingSumsOfSameCur()
        {
            if(currencies != null)
            {
                var groupedByNames = from a in currencies
                                     group a by a.CurrName
                                     into g
                                     select new Currency((from b in g select b.Amount).Sum(),g.Key);
                foreach (var item in groupedByNames)
                {
                    Console.WriteLine(item);
                }
                totAmount = groupedByNames.ToList();
                
            }
            else
            {
                ReadFromFile();
                PrintOnlyGrn();
            }
        }
        internal static void ConvertingAllCurrenciesToOne()
        {
            if(totAmount!=null)
            {
                Console.WriteLine("That`s all of the money we have in stock:");
                foreach (var item in totAmount)
                {
                    Console.WriteLine($"-{item}");
                }

                Console.WriteLine("\nPlease choose the currency, in which you would like to receive your money:\n");
                Console.WriteLine();
                bool isAvailable = false;
                string buttonPressed = string.Empty;
                while(!isAvailable)
                {
                    isAvailable = true;
                    Console.WriteLine("---Press 1 to convert into dollars");
                    Console.WriteLine("---Press 2 to convert into grivnas");
                    Console.WriteLine("---Press 3 to convert into euros");
                    buttonPressed = Console.ReadLine();
                    if(buttonPressed!= "1"&&buttonPressed!="2"&&buttonPressed!="3")
                    {
                        Console.WriteLine("Please try again!");
                        isAvailable = false;
                        Console.Clear();
                    }
                }
                Currency converted= null;
                switch(buttonPressed)
                {
                    case "1":
                        converted = CurrencyConverter.ConvertTo2(CurrencyName.Dollar, totAmount);
                        break;
                    case "2":
                        converted = CurrencyConverter.ConvertTo2(CurrencyName.Grivna, totAmount);
                        break;
                    case "3":
                        converted = CurrencyConverter.ConvertTo2(CurrencyName.Euro, totAmount);
                        break;
                }
                Console.WriteLine(converted);
            }
            else
            {
                PrintingSumsOfSameCur();
                ConvertingAllCurrenciesToOne();
            }
        }
    }
}
