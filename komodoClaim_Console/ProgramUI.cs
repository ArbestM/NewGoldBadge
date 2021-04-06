using KomodoClaim;
using KomodoClaim_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komodoClaim_Console
{
      class ProgramUI
      {
            private ClaimReport _fileReport = new ClaimReport();
            bool run = true;
            public void Run()
            {
                  SeedFile();
                  SeedIds();
                  MainMenu();
            }

            public void MainMenu()
            {
                  Console.Clear();
                  
                  while (run == true)
                  {
                        Console.Clear();
                        Console.WriteLine("Please Choose an option\n" +
                        "1. See all claim\n" +
                        "2. Take care of next claim\n" +
                        "3. View claim by Id\n" +
                        "4. Create a claim");

                        string select = Console.ReadLine();

                        switch (select)
                        {
                              case "1":
                                    {
                                          DisplayAllClaim();
                                          break;
                                    }

                              case "2":
                                    {
                                          UpDateList();
                                          break;

                                    }
                              case "3":
                                    {
                                          DisplayByClaimId();
                                          break;
                                    }
                              case "4":
                                    {
                                          CreateReport();
                                          break;
                                    }
                        }

                  }

            }

            private void CreateReport()
            {
                  Console.Clear();
                  ClaimRepo newClaim = new ClaimRepo();

                  Random runNumber = new Random();
                  long ClaimID = runNumber.Next(100 * 100) - 1;
                  double TenDaysOrless = ClaimID * 20 / 100;
                  double T2daysOrless = ClaimID * 30 / 100; 
                  double T3days = ClaimID * 45 / 100;


                  Console.Write("This is the refference number assign to this claim :" + $"{ClaimID}\n" +
                  $"Enter claim ID: ");
                  newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());
                  Console.WriteLine("\nWhat is the type of the claim\n" +
                                     "1. Car\n" +
                                     "2. Home\n" +
                                    "3. Theft");
                  string typeOfClaim = Console.ReadLine();
                  int type = int.Parse(typeOfClaim);
                  newClaim.Type = (ClaimType)type;
                  Console.Write("\nPlease provide the description of this claim : ");
                  newClaim.Description = Console.ReadLine();
                  Console.Write("Please provide the incident date use this format for date(mm/dd/yy) :");
                  newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine().ToString());
                  Console.Write("Please provide the report date of this cliam (mm/dd/yy): ");
                  newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine().ToString());
                  Console.WriteLine(($"\nThe Incendent has to be report withim 30 days please check for validation\n" +
                     $"Total days: " + (newClaim.DateOfClaim - newClaim.DateOfIncident).TotalDays));
                        Console.WriteLine("\nIs the claim valid (y/n)");

                  string ab = Console.ReadLine().ToLower();
                  newClaim.IsValid = run;
                  if (ab == "y"&& newClaim.DateOfClaim < newClaim.DateOfIncident.AddDays(30) ) 
                  {
                        Console.WriteLine("The total amount for this claim => " + $"$ {newClaim.ClaimAmount = TenDaysOrless}\n" +
                             $"Enter this Amount : ");
                        Console.ReadLine();
                       
                        
                       
                  }else if ((newClaim.DateOfClaim - newClaim.DateOfIncident).Days <= 10)
                  {
                      Console.Write("The total amount for this claim " + $"{newClaim.ClaimAmount = T2daysOrless}\n" +
                       $"Enter this Amount : ");
                        Console.ReadLine();
                  }
                  else
                  {
                        newClaim.IsValid =false;
                  }
                  _fileReport.AddClaim(newClaim);
            }

            private void DisplayAllClaim()
            {
                  Console.Clear();
                  Queue<ClaimRepo> file = _fileReport.ClaimerList();
                  Console.Write($"Claim ID\tType\tDescription\t\tAmount\t\t" + (" DateOfAccident\t\t DateOfClaim\n"));
                  foreach (ClaimRepo claim in file)
                  {

                     Console.WriteLine($"{claim.ClaimID}\t\t" + $"{claim.Type}");
                        Console.ReadLine();
                        break;
                  }
                 
                 
            } 

            public void DisplayByClaimId()
            {
                  Console.Clear();
                  Console.WriteLine("Please enter the claim refference ID number to see more details");
                  string UserInput = Console.ReadLine();
                  int convertIn = int.Parse(UserInput);
                  Console.Clear();
                  ClaimRepo claim = _fileReport.GetListByClaimId(convertIn);
                  Console.Write($"Claim ID\tType\tDescription\t\tAmount\t\t" + (" DateOfAccident\t\t DateOfClaim\n"));
                  if (claim != null)
                  {
                        Console.WriteLine($"{claim.ClaimID}\t\t" + $"{claim.Type}\t"+$"{claim.Description}\t" +
                        $"{claim.ClaimAmount}\t\t"+$"{claim.DateOfIncident.Date}\t"+$"{claim.DateOfClaim.Date}");
                        _fileReport.GetNextClaim();
                        Console.ReadLine();
                        
                        Console.Clear();
                       
                  }
                  else
                  {
                        Console.WriteLine("Claim id Could not be found");
                  }
                  
            }

            private void UpDateList()
            {
                  Console.Clear();
                  DisplayAllClaim();
                  ClaimRepo updClaim = new ClaimRepo();
                  Random runNumber = new Random();
                  long ClaimID = runNumber.Next(100 * 100) - 1;
                  double TenDaysOrless = ClaimID * 20 / 100;
                  double T2daysOrless = ClaimID * 30 / 100;
                  double T3days = ClaimID * 45 / 100;
                  Console.WriteLine("\nEnter the claimID to update file please use your keypod a number ");
                  string UserInput = Console.ReadLine();
                  int convertIn = int.Parse(UserInput);
                  ClaimRepo claim = _fileReport.GetListByClaimId(convertIn);


                  Console.Clear();

                  while (run)
                  {
                       if (convertIn == claim.ClaimID)
                       {

                              Console.WriteLine($"ClaimID : {claim.ClaimID}\n" +
                                  $"ClaimType : {claim.Type}\n" +
                                  $"Description : {claim.Description}\n" +
                                  $"ClaimAmount : $ {claim.ClaimAmount}\n" +
                                    $"DateOfIncident : {claim.DateOfIncident.ToString("mm/MM/dd")}\n" +
                                    $"DateOfClaim : {claim.DateOfClaim.ToString("mm/MM/dd")}\n" +
                                  $"IsValid : {claim.IsValid}");
                              Console.WriteLine("\nIs this claimID correct (y/n)");
                              string ac = Console.ReadLine();
                              if (ac == "y")
                              {
                                
                                    Console.Write("This is the refference number assign to this claim :" + $"{ClaimID}\n" +
                                    $"Enter claim ID:");
                                    updClaim.ClaimID = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("\nWhat is the type of the claim\n" +
                                                       "1. Car\n" +
                                                       "2. Home\n" +
                                                      "3. Theft");
                                    string typeOfClaim = Console.ReadLine();
                                    int type = int.Parse(typeOfClaim);
                                    updClaim.Type = (ClaimType)type;
                                    Console.Write("\nPlease provide the description of this claim : ");
                                    updClaim.Description = Console.ReadLine();
                                    Console.Write("Please provide the incident date use this format for date(mm/dd/yy) :");
                                    updClaim.DateOfIncident = DateTime.Parse(Console.ReadLine().ToString());
                                    Console.Write("Please provide the report date of this cliam (mm/dd/yy): ");
                                    updClaim.DateOfClaim = DateTime.Parse(Console.ReadLine().ToString());
                                    Console.WriteLine(($"\nThe Incendent have to be claim withim 30 days please check for validation\n" +
                                       $"Total days \t" + (updClaim.DateOfClaim - updClaim.DateOfIncident).TotalDays));
                                    Console.WriteLine("\nIs the claim valid (Y/N)");

                                    string ab = Console.ReadLine().ToLower();

                                    if (ab == "y" && updClaim.DateOfClaim < updClaim.DateOfIncident.AddDays(30))
                                    {
                                          Console.WriteLine("The total amount for this claim: " + $"{updClaim.ClaimAmount == TenDaysOrless}\n" +
                                               $"Enter this Amount");
                                          updClaim.IsValid = run;
                                          if ((updClaim.DateOfClaim - updClaim.DateOfIncident).Days <= 10)
                                          {

                                                Console.WriteLine("The total amount for this claim: " + $"{updClaim.ClaimAmount == T2daysOrless}\n" +
                                                $"Enter this Amount");
                                                Console.ReadLine();
                                          }
                                    }
                                    else
                                    {
                                          Console.WriteLine("Sorry this report can not be claimed press enter to continue");
                                          
                                    }
                                    Console.ReadLine();
                                    Console.Clear();
                                    MainMenu();
                              }
                              _fileReport.UpdateListOfClaim(convertIn, updClaim);

                       }
                       
                  }
            }


            private void DeleteExistingClaim()
            {
                  Console.Clear();
                  Console.Write("\nEnter the file id number you'd like to remove ");
                  string UserInput = Console.ReadLine();
                  int UserI = int.Parse(UserInput);
                  bool ClaimRemove = _fileReport.DeleteClaimFromFile(UserI);
                  if (ClaimRemove)
                  {
                        Console.WriteLine("File was removed from the list");
                        _fileReport.GetNextClaim();
                        
                  }
                  else
                  {
                        Console.WriteLine("failed");
                        
                  }
                  Console.ReadLine();
                  Console.Clear();

            }


            public void SeedFile()
            {
                  Console.Clear();
                  ClaimRepo car = new ClaimRepo(1, ClaimType.Car, "Car accident on 465.", (double)400.00, new DateTime(4/25/18).Date, new DateTime(4/27/18).Date, true);
                  ClaimRepo home = new ClaimRepo(2, ClaimType.Home, "House fire in kitchen.", (double)4000 + .00, new DateTime(4/12/18).Date, new DateTime(4/12/18).Date, false);
                  ClaimRepo theft = new ClaimRepo(3, ClaimType.Theft, "Stolen pancakes\t", (double)4 + 00, new DateTime(4/27/18).Date, new DateTime(6/01/18).Date, false);
                  _fileReport.AddClaim(car);
                  _fileReport.AddClaim(home);
                  _fileReport.AddClaim(theft);

            }
            public void SeedIds()
            {
                  ClaimRepo cr = new ClaimRepo(1, ClaimType.Car);
                  ClaimRepo hme = new ClaimRepo(2, ClaimType.Home);
                  ClaimRepo thft = new ClaimRepo(3, ClaimType.Theft);
                  _fileReport.AddClaim(cr);
                  _fileReport.AddClaim(hme);
                  _fileReport.AddClaim(thft);
            }
           
      }
}
      

