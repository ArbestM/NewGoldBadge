using KomodoClaimRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace komodoCoffee_UnitTest
{
      [TestClass]
      public class CoffeeShopTest
      {
            ItemDetails itemContent;
            ItemDetailsRepo repo;
            [TestInitialize]
            public void Arrange()
            {
                  itemContent = new ItemDetails();
                  repo = new ItemDetailsRepo();      
            }


            [TestMethod]
            public void AddTest()
            {
                  repo.AddInventory(itemContent);
                  Assert.IsNotNull(repo);

            }
            [TestMethod]
            public void DisplayTest()
            {
                  repo.AddInventory(itemContent);
                  Assert.IsNotNull(repo);
            }
            [TestMethod]
            public void DeleteTest()
            {
                  List<ItemDetails> numbers = repo.GetInventory();
                  numbers.Add(itemContent);
                   bool result= repo.DeleteItemFromInventory(itemContent.IdNumber);

                  Assert.IsTrue(result);
            }
            [TestMethod]
            public void DisplayById()
            {
                  List<ItemDetails> numbers = repo.GetInventory();
                  numbers.Add(itemContent);
                  repo.GetItemById(itemContent.IdNumber);

                  Assert.IsNotNull(itemContent);
            }
            
            public void SeedData()
            {
                  itemContent = new ItemDetails(5, "Blonde Roast", "Light roasted coffe that's soft,mellow and flavorful." +
                  "Easy-drinking on its own", "jhj", (double)3.21, 6, ProductType.HottCoffe);
                  repo.AddInventory(itemContent);
            }
      }
}