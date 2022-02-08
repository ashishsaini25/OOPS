using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAccountManagement
{
    public class StockExchange
    {
        public void StockReport(string FilePath)
        {
            try
            {
                string json;
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    json= reader.ReadToEnd();
                    var stocks= JsonConvert.DeserializeObject<List<Describe>>(json);
                    Console.WriteLine("\t " + "Stock Report");
                    Console.WriteLine("Name\t\t\t" + "Unit\t\t" + "UnitPrice\t\t" + "Total Value Of Stocks\t\t");
                    Int64 totalvalue = 0;
                    foreach (var data in stocks)
                    {
                        Console.WriteLine(data.Name + "\t\t\t" + data.NumberOfShare + "\t\t\t" + data.SharePrice +"\t\t\t"+data.NumberOfShare*data.SharePrice);
                        totalvalue += data.SharePrice * data.NumberOfShare;
                    }
                    Console.WriteLine("Total stock Value\t {0}", totalvalue);


                }
                    
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
