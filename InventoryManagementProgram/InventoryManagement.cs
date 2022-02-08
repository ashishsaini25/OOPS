using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementProgram
{
    public class InventoryManagement
    {

        List<Inventory> ricelist=new List<Inventory>();
        List<Inventory> wheatlist=new List<Inventory>();
        List<Inventory> pulseslist=new List<Inventory>();
        public void ReadDate(string filepath)
        {
            
            using (StreamReader reader= new StreamReader(filepath))
            {
                var json= reader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<InventoryFactory>(json);
                this.ricelist = items.Rice;
                this.wheatlist=items.Wheat;
                this.pulseslist = items.Pulses;
            }
        }
        public void Display(List<Inventory> temp)
        {

            if (temp.Capacity == 0)
            {
                Console.WriteLine("List is empty\n");
                return;
            }
            Console.WriteLine("name\t" + "price\t" + "weight\t" + "total amount");
            foreach (var data in temp)
            {
                Console.WriteLine(data.Name + "\t" + data.Price + "\t" + data.Weight + "\t" + data.Price * data.Weight);
            }

        }
        public void Add(List<Inventory> temp,int option,Inventory curr )
        {
          //  Console.WriteLine("Enter the name that you want to add  with weight and price");
            string name = curr.Name;
            foreach (var data in temp)
            {
                if(data.Name == name)
                {
                    Console.WriteLine("This variety exist in the inventory");
                    return;
                }
            }
            if (option == 1)
            {
                ricelist.Add(curr);
            }
            if (option == 2)
            {
                wheatlist.Add(curr);
            }
            if (option == 3)
            {
                pulseslist.Add(curr);
            }        
        }
        public Inventory Input()
        {
            Inventory inventory = new Inventory();
            Console.WriteLine("Enter the name ");
            inventory.Name = Console.ReadLine();
            Console.WriteLine("Enter the Weight ");
            inventory.Weight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Price");
            inventory.Price = Convert.ToInt32(Console.ReadLine());
            return inventory;
        }
        public void Write(string Filepath)
        {
            try
            {
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Enter the option: 1 to add Rice\n 2 to add Wheat\n 3 to add pulses\n 4 To display Inventory Items\n"+"5 to exit");
                    int option = Convert.ToInt32(Console.ReadLine());
                    Inventory inventory = new Inventory();

                    switch (option)
                    {
                        case 1:
                            inventory = Input();
                            Add(ricelist, option, inventory);
                            break;
                        case 2:
                            inventory = Input();
                            Add(wheatlist, option, inventory);
                            break;
                        case 3:
                            inventory = Input();
                            Add(pulseslist,option, inventory);
                            break;
                        case 4:
                            Display(ricelist);
                            Display(wheatlist);
                            Display(pulseslist);
                            break;
                        case 5:
                            flag = false;
                            break;

                    }
                }
                InventoryFactory inventoryFactory=new InventoryFactory();
                inventoryFactory.Rice = ricelist;
                inventoryFactory.Wheat = wheatlist;
                inventoryFactory.Pulses = pulseslist;
                var item = JsonConvert.SerializeObject(inventoryFactory);
                File.WriteAllText(Filepath, item);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

    }
}
