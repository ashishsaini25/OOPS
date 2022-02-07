using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManangement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryManagement inventoryManagement = new  InventoryManagement();
            inventoryManagement.ReadData(@"C:\Users\Lenovo\Desktop\git project\OOPS\InventoryManangement\Inventory.json");
            Console.ReadKey();
        }
    }
}
