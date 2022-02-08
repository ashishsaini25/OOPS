using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialDataProcessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StockManager manager = new StockManager();
            manager.ReadDataStock(@"C:\Users\Lenovo\Desktop\git project\OOPS\CommercialDataProcessing\StockExchange.json");
            manager.ReadDataUser(@"C:\Users\Lenovo\Desktop\git project\OOPS\CommercialDataProcessing\UserAccount.json");
            manager.Stockmarket(@"C:\Users\Lenovo\Desktop\git project\OOPS\CommercialDataProcessing\StockExchange.json", @"C:\Users\Lenovo\Desktop\git project\OOPS\CommercialDataProcessing\UserAccount.json");
            
        }
    }
}
