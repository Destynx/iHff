using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class WishList
    {
        int wishListCode = 0;
        List<BesteldItem> wishList = new List<BesteldItem>();

        public void NewList()
        {
            Random rnd = new Random();
            wishListCode = rnd.Next(0, 999999);
        }
    }
}