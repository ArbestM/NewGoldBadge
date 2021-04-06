using KomodoBadge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Console
{
      public class ProgramUI
      {
            BadgeRepository _newEntry = new BadgeRepository();
            BadgeContent bagdes = new BadgeContent();


            bool run = true;


            public void Run()
            {
                  SeedMethod();
                 
                  Menu();
            }
            
            private void Menu()
            {
                  Console.Clear();
                  while (run)
                  {

                        Console.WriteLine("Hello Security Admin, What would you like to do: \n" +
                              "1. Add a badge\n" +
                              "2. Edit a badge.\n" +
                              "3. List all Badges.\n" +
                              "4. Exit");
                        string select;
                        select = Console.ReadLine();
                        switch (select)
                        {
                              case "1":
                                    {
                                          CreateKeyAndValue();
                                          break;
                                    }
                              case "2":
                                    {
                                          UpdateDictionary();
                                          break;
                                    }
                              case "3":
                                    {
                                          
                                          DisplayAllDoors();
                                          break;
                                    }
                              default:
                                    {
                                          run = false;
                                          break;
                                    }
                        }

                  }

            }

            private void CreateKeyAndValue()
            {
                  Console.Clear();
                  List<string> newList = new List<string>();
                  BadgeContent newBadge = new BadgeContent();
                  Console.WriteLine("What is the number on the badge:");
                  newBadge.BadgeID = int.Parse(Console.ReadLine());

                  Console.WriteLine("List a door that it needs access to:");
                  string firstDoor = Console.ReadLine();
                  newList.Add(firstDoor);
                  newBadge.DoorsName = newList;
                 
                  Console.WriteLine("Is there any other door you'd like to attach to badge number (Y/N)");
                  string userInput = Console.ReadLine();
                  if (userInput == "y")
                  {
                        Console.Write("Enter the door name : ");
                        string secondDoor = Console.ReadLine().ToLower();
                        newBadge.DoorsName.Add(secondDoor);
                  }
                 
                  if (userInput == "n")
                  {
                        Console.WriteLine("Thank you your hard work is appriciated");
                        Console.ReadLine();
                        Menu();
                  }
                  _newEntry.AddToDict(newBadge);
                  Console.Clear();

            }

            private void DisplayAllDoors()
            {
                  Console.Clear();
                  Console.WriteLine("BADGE ID\tEntries Name\n");
                  foreach(var code in _newEntry._dict.Keys)
                  {
                        foreach(var entry in _newEntry._dict[code])
                        {
                              Console.Write($" "+code);
                              Console.WriteLine($"\t\t"+ entry.ToUpper());
                        }
                        Console.WriteLine();
                        
                  }
                  Console.WriteLine("Press enter to exit the function");
                  Console.ReadLine();
                  Console.Clear();
            }

            private void UpdateDictionary()
            {
                  Console.Clear();
                  Console.WriteLine("What is the badge number to update?");
                  int input = Convert.ToInt32(Console.ReadLine());
                  Console.Clear();
                  var checkInput = _newEntry._dict;
                 
                  if (checkInput.ContainsKey(input))
                  {
                       
                        Console.Write(input+" has access to door ****\n");


                        foreach (string door in _newEntry._dict[input])
                        {
                              Console.WriteLine("\t\t\t" + door.ToUpper());
                                 
                        }
                        Console.WriteLine(" Press enter to continue ");
                        Console.ReadLine();


                        Console.Clear();
                        Console.WriteLine("What would you like to do\n" +
                              "1. Remove\n" +
                              "2. Add a door");
                        int userInput = Convert.ToInt32(Console.ReadLine());
                        switch (userInput)
                        {
                              case 1:
                                    {
                                          Console.Clear();
                                          Remove();
                                          break;
                                    }
                              case 2:
                                    {
                                          Console.Clear();
                                          AddSingleDoor();
                                          break;
                                    }
                        }
                        

                  }
                  if (!checkInput.ContainsKey(input))
                  {
                        Console.WriteLine("Access code could not be found");
                        Console.ReadKey();
                  }
                  Menu();
                  
                

                 
            }

            public void AddSingleDoor()
            {
                  Console.Clear();
                  List<string> UpdateList = new List<string>();
                  Console.WriteLine("Enter the door name you'd like to add");
                  string doorName = Console.ReadLine().ToLower();
                  Console.WriteLine("Enter the key id for validation");
                  int validation = Convert.ToInt32(Console.ReadLine());
                  bagdes.BadgeID = validation;
                  UpdateList.Add(doorName);
                  bagdes.DoorsName = UpdateList;

                  _newEntry.AddToDict(bagdes);


            }

            public void Remove()
            {
                  Console.Clear();
                  Console.WriteLine("Use your keypad to enter the door name you'd like to remove");
                  string UserInput = Console.ReadLine().ToLower();
                  bool wasRemoved = _newEntry.RemoveDoorFromList(UserInput);
                  if(wasRemoved)
                  {
                        Console.WriteLine($"{UserInput}" +": Was removed from the list of doors");
                        Console.ReadLine();
                  }
                  if (wasRemoved==false)
                  {
                        Console.WriteLine($"{UserInput} : does not exist in any avaible list of doors please press enter to continue");
                        Console.ReadLine();
                  }
                  
                  
            }


            public void SeedMethod()
            {
                  List<string> listOfEastEnties = new List<string>();
                  List<string> listOfWestEnties = new List<string>();
                  
                  listOfEastEnties.Add("e1"); listOfWestEnties.Add("w1");
                  listOfEastEnties.Add("e2");  listOfWestEnties.Add("w2");
                  listOfEastEnties.Add("e3");  listOfWestEnties.Add("w3");
                  listOfEastEnties.Add("e4"); listOfWestEnties.Add("w4");
                  _newEntry._dict.Add(22345, listOfWestEnties);
                  _newEntry._dict.Add(24345, listOfEastEnties);
                 
                  _newEntry._dict.Add(0555, listOfEastEnties);
                  
            }
      }
}
