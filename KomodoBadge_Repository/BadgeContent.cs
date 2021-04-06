using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Repository
{
      public class BadgeContent
      {
           
            public int BadgeID { get; set; }
            public List<string>DoorsName { get; set; }
            public string BadgeName { get; set; }

          

            public BadgeContent() { }

            public BadgeContent(int badgeId, List<string> doorName)
            {
                  BadgeID = badgeId;
                  DoorsName = doorName;
            }

            public BadgeContent(List<string> doorName)
            {
                  
                  DoorsName = doorName;
            }


            public BadgeContent(int badgeId, List<string> doorName, string badgeName)
            {
                  BadgeID = badgeId;
                  DoorsName = doorName;
                  BadgeName = badgeName;
            }

            
      }

}
