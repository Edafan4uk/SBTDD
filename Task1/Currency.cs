using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Currency : IReadable
    {
        public string CurrencyName { get; set; }
        public double Amount { get; set; }
        public Currency()
        {
            CurrencyName = string.Empty;
            Amount = 0;
        }
        public Currency(double am, string cur)
        {
            Amount = am;
            CurrencyName = cur;
        }
        public void Read(StreamReader streamReader)
        {
            string temp = streamReader.ReadLine();
            string[]splitString = temp.Split(',',' ',';');
            double amount = 0;
            try
            {
                if (splitString[0] == string.Empty || splitString[1] == string.Empty)
                    throw new ArgumentNullException("There is nothing to read from file!");
            }
            catch(ArgumentNullException argNullEx)
            {
                Console.WriteLine(argNullEx.ToString());
            }
            try
            {
                if ((!double.TryParse(splitString[0], out amount)))
                    throw new FormatException("You try to convert not a number to a number!");
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Amount = amount;
            CurrencyName = splitString[1];

        }
           

        
    } 
}
