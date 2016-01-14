using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using IHFF.Classes;

namespace IHFF.Controllers
{
    public class WishlistController : Controller
    {
        //
        // GET: /Bestelling/

        WishlistItem wishlistitem;
        WishList wishlist;
        int code;
        public ActionResult Index()
        {
            return View();
            
        }



        //Om een item te verwijderen
        public ActionResult DeleteItem(WishList wishlist)
        {
            DatabaseHandler.UpdateWishlist(wishlist);
            return View(wishlist);
        }

        //Om een item uit de wishlist aan te passen
        public ActionResult EditItem(WishList wishlist)
        {
            DatabaseHandler.UpdateWishlist(wishlist);
            return View();
        }

        //Om naar de betaling te gaan
        public ActionResult Payment(WishList wishlist)
        {

            return View();
        }

        //Om de wishlist op te slaan
        public ActionResult SaveWishlist(WishList wishlist)
        {
            
            DatabaseHandler.UpdateWishlist(wishlist);
            return View(); 

        }

        public ActionResult RetrieveWishlist(string tekst)
        {
            int code = int.Parse(tekst);
            this.wishlist = DatabaseHandler.GetWishlist(code);
            return View(wishlist.itemList);
        }
    }
}