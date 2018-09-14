using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Currency: IReadable
    {
        public string CurrencyName { get; set; }
        public double Amount { get; set; }
        public Currency()
        {
            CurrencyName = string.Empty;
            Amount = 0;
        }
        public void Read(string Path)
        {
            FileInfo fileInfo = new FileInfo(Path);
            if (!fileInfo.Exists)
                throw new FileNotFoundException();
            else
            {
                using (StreamReader streamReader = new StreamReader(fileInfo.FullName))
                {
                    string StringFromFile = string.Empty;
                    try
                    {
                        StringFromFile = streamReader.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                    string[] StringArrayFromFile = StringFromFile.Split();
                    try
                    {
                        Amount = Double.Parse(StringArrayFromFile[0]);
                        CurrencyName = StringArrayFromFile[1];
                    }
                    catch (FormatException ex)
                    {
                        ex.ToString();
                    }
                }
            }
        }
        public void Write(string Path)
        {
            FileInfo fileInfo = new FileInfo(Path);
            if (!fileInfo.Exists)
                fileInfo.Create();
            using (StreamWriter streamWriter = new StreamWriter(fileInfo.FullName))
            {
                streamWriter.Write(Amount);
                streamWriter.Write(CurrencyName);
            }
        }

    }
}
