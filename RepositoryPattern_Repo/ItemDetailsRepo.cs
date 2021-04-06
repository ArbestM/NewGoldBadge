using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimRepository
{
    public class ItemDetailsRepo
    {
         List<ItemDetails> _inventoryOfItems = new List<ItemDetails>();
      

       
        public void AddInventory(ItemDetails article)
        {        
                  _inventoryOfItems.Add(article);
        }

        public List<ItemDetails>  GetInventory()
        {
            return _inventoryOfItems;
        }

        public bool DeleteItemFromInventory(int IdNumber)
        {


            ItemDetails item = GetItemById(IdNumber);
            if (item == null)
            {
                       
                return false;
            }


            int OriginalCount = _inventoryOfItems.Count;
            _inventoryOfItems.Remove(item);
                  int Actualcount = _inventoryOfItems.Count;

            if (Actualcount < OriginalCount)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        

       
        public  ItemDetails GetItemById(int IdNumber)
        {
           foreach(ItemDetails article in _inventoryOfItems)
           {
                if (article.IdNumber == IdNumber)
                {
                              return article;
                }
           }

            return null;
        }

    }
}
