using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    /// <summary>
    /// Main class with tasks.
    /// </summary>
    /// <remarks>
    /// This class contains methods for implementing reading from a file, outputting only the Ukrainian currency,
    /// converting currencies to one, deducting the amount of a particular currency.
    /// </remarks>
    internal static class Tasks
    {
        /// <value>List of all currencies.</value>
        private static List<Currency> currencies;
        /// <value>List which contains sum of all currencies.</value>
        private static List<Currency> totAmount; 

        /// <summary>
        /// Reading pairs "currency - amount" from text file and print on console.
        /// </summary>
        internal static void ReadFromFile()
        {
            try
            {
                currencies = new List<Currency>(); // creating list of currencies
                if (!File.Exists(@"C:\Users\Oleg\SBTDD\Task1\ReadFromHere.txt")) // check if there is a folder in the specified path
                    throw new FileNotFoundException();
                
                using (StreamReader sr = File.OpenText(@"C:\Users\Oleg\SBTDD\Task1\ReadFromHere.txt")) // creating stream for reading data
                {
                    ///<value>Temporary variable for convenient reading. </value>
                    Currency tempCurr;
                    while(!sr.EndOfStream)
                    {
                        tempCurr = new Currency();
                        tempCurr.Read(sr);
                        if(!tempCurr.HasMissingField) // if data entered correctly, add to list of currencies
                            currencies.Add(tempCurr);
                    }
                }
                foreach (var item in currencies) // printing data on concole
                {
                    Console.WriteLine(item);
                }
            }
            catch(FileNotFoundException ex)
            {
                //exception in case the file doesn`t open 
                Console.WriteLine(ex.Message);
            }
            
        }
        /// <summary>
        /// This method prints only ukrainian currency.
        /// </summary>
        internal static void PrintOnlyGrn()
        {
            if (currencies != null) // check if the list is empty
            {
                var onlyGrn = from a in currencies where a.CurrName == CurrencyName.Grivna select a; // variable onlyGrn contains only grivnas
                foreach (var item in onlyGrn)
                {
                    Console.WriteLine(item); // printing
                }
            }
            else
            {
                ReadFromFile(); 
                PrintOnlyGrn();
            }
        }

        /// <summary>
        /// Printing the sum of the desired currency
        /// </summary>
        internal static void PrintingSumsOfSameCur()
        {
            if(currencies != null)
            {
                ///<value>Contains a sum of each currency. </value>
                var groupedByNames = from a in currencies
                                     group a by a.CurrName
                                     into g
                                     select new Currency((from b in g select b.Amount).Sum(),g.Key);// Merge same cuurency together 
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
        /// <summary>
        /// Convert all currencies to one.
        /// </summary>
        internal static void ConvertingAllCurrenciesToOne()
        {
            if(totAmount!=null) // Check if toatal amount list isnt empty
            {
                Console.WriteLine("That`s all of the money we have in stock:");
                foreach (var item in totAmount) // printing amount of each currency
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
                    if(buttonPressed!= "1"&&buttonPressed!="2"&&buttonPressed!="3") //сусle while continue untill user enter correct data (1,2,3)
                    {
                        Console.WriteLine("Please try again!");
                        isAvailable = false;
                        Console.Clear();
                    }
                }
                Currency converted= null;
                switch(buttonPressed) // Printing results depends on what user entered
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
