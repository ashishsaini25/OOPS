using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAccountManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StockExchange stockExchange = new StockExchange();
            stockExchange.StockReport(@"C:\Users\Lenovo\Desktop\git project\OOPS\StockAccountManagement\Stocks.json");
        }
    }
}
