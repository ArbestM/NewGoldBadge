using KomodoBadge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoBadge__Test
{
      [TestClass]
      public class BadgesTest
      {
            BadgeContent content;
            BadgeRepository repo;
           

            [TestInitialize]
            public void Arrange()
            {
                  content = new BadgeContent();
                  repo = new BadgeRepository();
            }
            [TestMethod]
            public void AddToDict_Test()
            {

                  // --Act--
                  List<string> eastEntry = new List<string>();
                  eastEntry.Add("e5");
                  eastEntry.Add("e6");
                  content = new BadgeContent(123456, eastEntry);
                  repo.AddToDict(content);
                  //--Assert--
                  Assert.IsNotNull(repo);
            }

            [TestMethod]
            public void RemoveFromList()
            {

                  // --Act--

                  List<string> remove = new List<string>();
                  remove.Add("w1");
                  remove.Add("w1");
                  content = new BadgeContent(123456, remove);
                  repo.AddToDict(content);
                 bool delt = repo.RemoveDoorFromList("w1");
                  //--Assert--
                  Assert.IsTrue(delt);
            }
            
      }
}
