using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    internal enum CurrencyName
    {
        Grivna,
        Dollar,
        Euro
    }
    internal class Currency : IReadable
    {
        public bool HasMissingField { get; private set; }
        public CurrencyName CurrName { get; private set; }        
        public double Amount { get;private set; }
        public Currency()
        {
            HasMissingField = false;
            CurrName = default(Task1.CurrencyName);
            Amount = 0;
        }
        public Currency(double am, CurrencyName cur)
        {
            HasMissingField = false;
            Amount = am;
            CurrName = cur;
        }
        public void Read(StreamReader streamReader)
        {
            string temp = streamReader.ReadLine();
            string[]splitString = temp.Split(',',' ',';');
            double amount = 0;
            try
            {
                if (splitString[0] == string.Empty || splitString[1] == string.Empty)
                    throw new ArgumentNullException();
                else if ((!double.TryParse(splitString[0], out amount)))
                    throw new FormatException();
                else
                {
                    Amount = amount;
                    string currName = splitString[1];
                    switch (currName)
                    {
                        case "grn":
                            CurrName = Task1.CurrencyName.Grivna;
                            break;
                        case "eur":
                            CurrName = Task1.CurrencyName.Euro;
                            break;
                        case "dol":
                            CurrName = Task1.CurrencyName.Dollar;
                            break;
                        default:
                            HasMissingField = true;
                            throw new Exception($"The is no such currency as { currName}");                           
                    }
                }
            }
            catch(ArgumentNullException argNullEx)
            {
                Console.WriteLine(argNullEx.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public override string ToString()
        {
            return string.Format($"Currency: {CurrName.ToString()};Amount: {Amount}");
        }
    } 
}
