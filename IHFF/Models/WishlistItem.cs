using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class WishlistItem
    {
        
        public Product item = new Product();
        public DateTime Besteltijd = new DateTime();
        public int StoelNummer;
        public int Aantal;

        public WishlistItem() { }

        public WishlistItem(int id, int amount)
        {

        }
    }
}