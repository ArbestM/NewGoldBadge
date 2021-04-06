
using KomodoClaim;
using KomodoClaim_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoClaim_UnitTest
{
      [TestClass]
      public class ClaimTest
      {
            ClaimRepo content;
            ClaimReport repository;
            
           [TestInitialize]
            public void Arrange()
            {
               content = new ClaimRepo();
               repository = new ClaimReport();
                 
            }
            [TestMethod]
            public void Add_Test()
            {
                  repository.AddClaim(content);
                  Assert.IsNotNull(repository);
            }

            [TestMethod]
            public void Update_Test()
            {
                  ClaimRepo updateContent = new ClaimRepo(32, ClaimType.Car);
                  repository.AddClaim(updateContent);
                  bool result = repository.UpdateListOfClaim(updateContent.ClaimID, content);
                  Assert.IsTrue(result);
            }

            [TestMethod]
            public void Delete_Test()
            {
                  Queue<ClaimRepo> claimI = repository.ClaimerList();
                  claimI.Enqueue(content);
                  bool wasDelete = repository.DeleteClaimFromFile(content.ClaimID);
                  Assert.IsTrue(wasDelete);
            }

            [TestMethod]
            public void GetById_Test()
            {
                  ClaimRepo content2 = new ClaimRepo(3,ClaimType.Car);
                  repository.AddClaim(content2);
                  Queue<ClaimRepo> _ClaimById = repository.ClaimerList();
                  _ClaimById.Enqueue(content2);
                
                    
            }

            public void SeedFile()
            {
               ClaimRepo content = new ClaimRepo(1, ClaimType.Car, "Car accident on 465.", (double)400.00, new DateTime(4 / 25 / 18).Date, new DateTime(4 / 27 / 18).Date, true);

               repository.AddClaim(content);
            }
      }
}
