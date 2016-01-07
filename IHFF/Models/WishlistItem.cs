using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class WishlistItem
    {
        //TODO: Dit dynamisch maken.
        public Product item = new Product();
        public DateTime Besteltijd = new DateTime();
        public int StoelNummer;
        public int Aantal;   
    }
}