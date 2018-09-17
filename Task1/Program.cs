using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading from file\n");
            Tasks.ReadFromFile();
            Console.WriteLine("\nPrinting only grivnas\n");
            Tasks.PrintOnlyGrn();
            Console.WriteLine("\nPrinting total amount of each currency\n");
            Tasks.PrintingSumsOfSameCur();
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nConvertingTo\n");
            Tasks.ConvertingAllCurrenciesToOne();
        }
    }
}
