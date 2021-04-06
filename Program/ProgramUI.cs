using java.lang;
using KomodoClaimRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Program
{
    public class ProgramUI
    {
      private   ItemDetailsRepo _itemRepo = new ItemDetailsRepo();
        


        public void Run()
        {
            SeedInventoryList();
            HouseKeeping();
            
        }
        
        // HouseKeeping is the first page will be display to the user to select a function based to start
       public void HouseKeeping()
       {
            
            bool run = true;
            while (run)
            {

                        
                        string option;
               
                Console.WriteLine("Select an Option, Between 1 to 4\n" +
                    "1. Add item to inventory\n" +
                    "2. view Current inventory\n" +
                    "3. Delete item from inventory\n"+
                    "4. view Article by id number");
                option = Console.ReadLine();
                        Console.Clear();
                        switch (option)
                        {
                              case "1":
                                    {
                                          // this will take the user to the adding fuction
                                          CreateNewInventory();
                                          break;
                                    }
                              case "2":
                                    {
                                          // this will take the user to view the inventory 
                                          ViewInventory();
                                          break;
                                    }

                              case "3":   
                                    {
                                          // this will take take the user to the delete function
                                          DeleteFromInventory();
                                          break;
                                    }
                              case "4":
                                    run = false;
                                    {


                                          // this is kinda an error message if the user type the invalid entry
                                          Console.WriteLine("Id number Could not be found please select type valid function press enter to continue");

                                          Console.ReadLine();
                                          break;
                                    }
                              default:
                                    {
                                          
                                          Console.WriteLine("\nThank you your hard work is appreciated");
                                          Console.ReadLine();
                                          Console.Clear();
                                          break;
                                    }


                        }



            }
                 


       }
       
       private void CreateNewInventory()
       {
            Console.Clear();

            ItemDetails newArticle = new ItemDetails();
                  

                Console.WriteLine("Enter the the article name of the item ?");
                  newArticle.Name = Console.ReadLine().ToLower();
                

                Console.WriteLine("Please enter item descrisption ");
                newArticle.Description = Console.ReadLine();

                Console.WriteLine("How much this item will cost ");
                newArticle.Price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("What refference id number would you like to assign to this item");
                newArticle.IdNumber = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("What is the item type use your keypad to select 1 to 5 \n" +
                    "1. Hot Coffee\n" +
                    "2. Hot Tea\n" +
                    "3. Frappuccio\n" +
                    "4. Cold Coffee\n" +
                    "5. Ice Tea");
                string Type = Console.ReadLine();
                int Typein = int.Parse(Type);
                newArticle.Type = (ProductType)Typein; /* casting*/

                Console.WriteLine("Homy Ingredient would you use for this product");
               newArticle.Ingredients = Console.ReadLine();
                Console.WriteLine("How many of this item you would to add in inventory");
                newArticle.Quatity = Convert.ToInt32(Console.ReadLine());
            _itemRepo.AddInventory(newArticle);


        } 

        private void ViewInventory()
        {
            
           
            List<ItemDetails> inventoryList = _itemRepo.GetInventory();
            foreach(ItemDetails Item in inventoryList)
            {
               if(Item != null)
               {
                   
                    Console.WriteLine($"Name: {Item.Name}\n"+
                        $"IdNumber: {Item.IdNumber}\n" +
                        $"{Item.Ingredients}");
                    Console.ReadLine();
                              break;
               }
               
            }
                  Console.Clear();
        }

        public void DeleteFromInventory()
        {
            Console.Clear();
            ViewInventory();
            
            int UserInput;
            List<ItemDetails> item = _itemRepo.GetInventory();

            Console.WriteLine("Please enter refference id number of the item you would like to delete");
            bool Delete = int.TryParse(Console.ReadLine(), out UserInput);

            if (Delete)
            {
                foreach(ItemDetails number in item)
                {
                    if(number.IdNumber == UserInput)
                    {
                        _itemRepo.DeleteItemFromInventory(UserInput);
                        Console.WriteLine("Item was removed");
                        Console.ReadLine();
                        HouseKeeping();
                    }
                }
            }
            
            

            
        }

        private void SeedInventoryList()
        {
                 
            ItemDetails blonde = new ItemDetails(5,"Blonde Roast","Light roasted coffe that's soft,mellow and flavorful." +
                  "Easy-drinking on its own","jhj", (double) 3.21,6,ProductType.HottCoffe);
            ItemDetails chai = new ItemDetails(6, "Chai Latte", "Black tea infused with cinnamon, clove and other warming spices is combined " +
                        "with steamd milk and topped with foam for the perfect balance of sweet nas spice.","gff",(double) 5.21,1,ProductType.HotTea);
            _itemRepo.AddInventory(blonde);
                  _itemRepo.AddInventory(chai);

        }


        
    }
}
