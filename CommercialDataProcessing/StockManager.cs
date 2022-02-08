using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialDataProcessing
{
    public class StockManager
    {
        List<Stock>stockexchange=new List<Stock>();
        List<Stock>user=new List<Stock>();
        int amount=10000;
        public void ReadDataStock(string Filepath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(Filepath))
                {
                    var json = reader.ReadToEnd();
                    var stock=JsonConvert.DeserializeObject<List<Stock>>(json);
                    this.stockexchange = stock;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
        public void ReadDataUser(string Filepath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(Filepath))
                {
                    var json = reader.ReadToEnd();
                    var stock = JsonConvert.DeserializeObject<List<Stock>>(json);
                    this.user = stock;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public void DisplayStockExchange()
        {
            foreach(var stock in this.stockexchange)
            {
                Console.WriteLine(stock.Companyname+ "\t"+ stock.NumberOfShares+ "\t"+ stock.PricePerShare); 
            }

        }
        public void DisplayUserAccount()
        {
            foreach (var stock in this.user)
            {
                Console.WriteLine(stock.Companyname + "\t" + stock.NumberOfShares + "\t" + stock.PricePerShare);
            }
            Console.WriteLine("The Current balance of the user :{0}", amount);

        }
        public void Buy()
        {
            Stock temp = new Stock();
            Stock temp1 = new Stock();
            Stock temp2 = new Stock();
            Console.WriteLine("Enter the Company name\n");
            temp.Companyname = Console.ReadLine();
            Console.WriteLine("Enter the Number of Units you  want to purchase\n");
            temp.NumberOfShares = Convert.ToInt32(Console.ReadLine());
            foreach(var stock in this.stockexchange)
            {
                if (stock.Companyname == temp.Companyname)
                {
                    temp.PricePerShare=stock.PricePerShare;
                    temp1=stock;
                }
            }

            int currentpurchase = temp.PricePerShare * temp.NumberOfShares;
            if (currentpurchase > this.amount)
            {
                Console.WriteLine("User dont have enough amount\n");
                return;
            }
            if(temp.NumberOfShares > temp1.NumberOfShares)
            {
                Console.WriteLine("Stock exchange does not have that much of stock\n");
                return;
            }
            stockexchange.Remove(temp1);
            temp1.NumberOfShares=temp1.NumberOfShares-temp.NumberOfShares;
            stockexchange.Add(temp1);
            amount-=currentpurchase;
            int currentstock = 0;
            bool userhave = false;
            foreach(var stock in this.user)
            {
                if (stock.Companyname == temp.Companyname)
                {   
                    currentstock=stock.NumberOfShares;
                    temp2 = stock;
                    userhave = true;
                }
            }
            if (userhave) user.Remove(temp2);
             temp.NumberOfShares += currentstock;
            user.Add(temp);
            Console.WriteLine("Purchased Done Successfully\n");
        }
        public void Sell()
        {
            Stock temp = new Stock();
            Stock temp1 = new Stock();
            Stock temp2 = new Stock();
            Console.WriteLine("Enter the CompanyName\n");
            temp.Companyname = Console.ReadLine();
            Console.WriteLine("Enter the Number of units you want to sell\n");
            temp.NumberOfShares = Convert.ToInt32(Console.ReadLine());
            bool userhave = false;
            foreach(var stock in this.user)
            {
                if (stock.Companyname == temp.Companyname)
                {
                    temp1 = stock;
                    temp.PricePerShare = stock.PricePerShare;
                    userhave=true;
                }
            }
            if (!userhave)
            {
                Console.WriteLine("User don't have the shares of the following company\n");
                return;
            }
            if(temp.NumberOfShares > temp1.NumberOfShares)
            {
                Console.WriteLine("User don't have that much of shares\n");
                return;
            }
            bool stockexcxhangehave = false;
            foreach(var stock in this.stockexchange)
            {
                if (stock.Companyname == temp.Companyname)
                {
                    stockexcxhangehave = true;
                    temp2 = stock;
                }
            }
            if (!stockexcxhangehave)
            {
                this.stockexchange.Add(temp);
            }
            else
            {
                this.stockexchange.Remove(temp2);
                temp2.NumberOfShares += temp.NumberOfShares;
                this.stockexchange.Add(temp2);
            }
            this.amount += temp.NumberOfShares * temp.PricePerShare;
            temp.NumberOfShares = temp1.NumberOfShares - temp.NumberOfShares;
            this.user.Remove(temp1);
            this.user.Add(temp);
            Console.WriteLine("Shares sold Successfully\n");
        }
        public void Stockmarket(string filepath1,string filepath2)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter 1 to view info about stocks available in stockmarket\n"
                    +"Enter 2 view User Account\n"+"Enter 3 to Buy Stock\n"
                    +"Enter 4 to sell stock\n"+
                    "Enter 5 to exit stock market\n");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        DisplayStockExchange();
                        break;
                    case 2:
                        DisplayUserAccount();
                        break;
                    case 3:
                        Buy();
                        break;
                    case 4:
                        Sell();
                        break;
                    case 5:
                        flag = false;
                        break;
                }
            }
            var item=JsonConvert.SerializeObject(this.stockexchange);
            File.WriteAllText(filepath1, item);
            item = JsonConvert.SerializeObject(this.user);
            File.WriteAllText(filepath2, item);

        }
    }
}
