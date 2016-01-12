using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class WishList
    {
        public int wishListCode = 0;
        public bool betaald = false;
        public List<WishlistItem> itemList = new List<WishlistItem>();
        public float TotaalPrijs;

        public void NewList()
        {
            Random rnd = new Random();
            wishListCode = rnd.Next(0, 999999);
        }
    }
}