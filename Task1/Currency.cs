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
    /// <summary>
    /// Class which represents Currency.
    /// </summary>
    /// <remarks>
    /// This class can сreate, read and print Currency.
    /// </remarks>
    internal class Currency : IReadable
    {
        ///<value>Shows if pair "currency - amount" is correct. </value>
        public bool HasMissingField { get; private set; }
        ///<value>Contains a one type of currency. </value>
        public CurrencyName CurrName { get; private set; }
        ///<value>Contains an amount of a certain currency.  </value>
        public double Amount { get;private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Currency()
        {
            HasMissingField = false;
            CurrName = default(Task1.CurrencyName);
            Amount = 0;
        }
        /// <summary>
        /// Constructor with paramers
        /// </summary>
        /// <param name="am">Amount</param>
        /// <param name="cur">Currency</param>
        public Currency(double am, CurrencyName cur)
        {
            HasMissingField = false;
            Amount = am;
            CurrName = cur;
        }

        /// <summary>
        /// Read a currency and amount from file.
        /// </summary>
        /// <param name="streamReader">Stream. </param>
        public void Read(StreamReader streamReader)
        {
            string temp = streamReader.ReadLine(); // Get the first line from streamReader and put in temp
            string[]splitString = temp.Split(',',' ',';'); // Divide into an array of rows to a comma.
            double amount = 0;
            try
            {
                if (splitString[0] == string.Empty || splitString[1] == string.Empty) // Throw exception in case it is empty
                    throw new ArgumentNullException();
                else if ((!double.TryParse(splitString[0], out amount))) // Trying convert from string to double and put in amount
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
                            throw new Exception($"There is no such currency as { currName}");                           
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
        /// <summary>
        /// Shows itself
        /// </summary>
        /// <returns>String in certain format.</returns>
        public override string ToString()
        {
            return string.Format($"Currency: {CurrName.ToString()};Amount: {Amount}");
        }
    } 
}
