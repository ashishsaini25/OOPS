using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Write(@"C:\Users\Lenovo\Desktop\git project\OOPS\InventoryManagementProgram\Items.json");
        }
    }
}
