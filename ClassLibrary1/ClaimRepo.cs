using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaim
{
      public enum ClaimType
      {
            Car = 1,
            Home,
            Theft
      }

      public class ClaimRepo
      {

            public int ClaimID { get; set; }
            public ClaimType Type { get; set; }
            public string Description { get; set; }
            public double ClaimAmount { get; set; }
            public DateTime DateOfIncident { get; set; }
            public DateTime DateOfClaim { get; set; }
            public bool IsValid { get; set; }


            public ClaimRepo() { }

            public ClaimRepo(int claimId, ClaimType type) { }


            public ClaimRepo(int claimId, ClaimType type, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
            {
                  ClaimID = claimId;
                  Type = type;
                  Description = description;
                  ClaimAmount = claimAmount;
                  DateOfIncident = dateOfIncident;
            }
      }
}
