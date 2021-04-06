using KomodoClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaim_Repository
{
      public class ClaimReport
      {
            // by using queue collection to represente my claims based on the priority to process
            private Queue<ClaimRepo> _claimfile = new Queue<ClaimRepo>();
            // Create
            public void AddClaim(ClaimRepo claim)
            {
                  _claimfile.Enqueue(claim);

            }
            // Read
            public Queue<ClaimRepo> ClaimerList()
            {
                  return _claimfile;
            }
            // Update
            public bool UpdateListOfClaim(int existList, ClaimRepo upDateClaim)
            {

                  ClaimRepo OldClaim = GetListByClaimId(existList);
                  if (OldClaim != null)
                  {
                        OldClaim.ClaimID = upDateClaim.ClaimID;
                        OldClaim.Type = upDateClaim.Type;
                        OldClaim.Description = upDateClaim.Description;
                        OldClaim.ClaimAmount = upDateClaim.ClaimAmount;
                        OldClaim.DateOfIncident = upDateClaim.DateOfIncident;
                        OldClaim.DateOfClaim = upDateClaim.DateOfClaim;
                        OldClaim.IsValid = upDateClaim.IsValid;
                        return true;
                  }
                  else
                  {
                        return false;
                  }

            }
            // Delete
            public bool DeleteClaimFromFile(int claimId)
            {

                  ClaimRepo IdClaim = GetListByClaimId(claimId);

                  if (IdClaim == null)
                  {
                        return false;
                  }

                  int orginalCount = _claimfile.Count;
                  _claimfile.Dequeue();

                  if (orginalCount > _claimfile.Count)
                  {
                        return true;
                  }
                  else
                  {
                        return false;
                  }
            }



            //Help method
            public ClaimRepo GetListByClaimId(int claimId)
            {

                  foreach (ClaimRepo IdClaim in _claimfile)
                  {
                        if (IdClaim.ClaimID == claimId)
                        {
                              return IdClaim;
                        }
                  }
                  return null;
            }

            public ClaimRepo GetNextClaim()
            {
                  if (_claimfile.Count > 0)
                  {
                        return _claimfile.Peek();
                  }
                  return null;
            }

      }


}
