using System.Collections.Generic;
using System.Linq;

namespace KomodoBadge_Repository
{
      public class BadgeRepository
      {
           public  Dictionary<int, List<string>> _dict = new Dictionary<int, List<string>>();

            public void AddToDict(BadgeContent badge)
            {
               _dict.Add(badge.BadgeID, badge.DoorsName);
            }


            public string GetBadgeById(int badgeId)
            {
                  var badgeExist = _dict;

                  if (badgeExist.ContainsKey(badgeId))
                  {
                        return badgeId.ToString();
                  }
                  else
                  {
                        return null;
                  }

            }
          

            public bool RemoveDoorFromList(string userInput)
            {
                  foreach (var code in _dict)
                  {
                        foreach (var kvpValue in code.Value)
                        {
                              if (kvpValue == userInput)
                              {
                                    code.Value.Remove(kvpValue);
                                    return true;
                              }

                        }

                  }
                  return false;
            }


            public List<int> GetListDigit()
            {
                  List<int> FullList = new List<int>();
                  foreach (var kvp in _dict)
                  {
                        FullList.Add(kvp.Key);
                  }
                  return FullList;

            }

      }
}
