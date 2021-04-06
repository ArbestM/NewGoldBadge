using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimRepository
{
    public enum ProductType
    {
        // enums types 
        HottCoffe=1,
        HotTea,
        Frappuccio,
        ColdCoffees,
        IceTea,
    }

    public class ItemDetails
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int  IdNumber { get; set; }
        public double Price { get; set; }
        public int Quatity { get; set; }
        public ProductType Type { get; set; }
        public string Ingredients { get; set; }
           
       public ItemDetails() { }

        public ItemDetails(int idNumber, string name, string description, string ingredients, double price, int quatity, ProductType type)
        {
            IdNumber = idNumber;
            Name =name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
            Quatity = quatity;
            Type= type;
            
        }

        
    }
    
}
