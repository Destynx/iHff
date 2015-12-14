using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;

namespace IHFF.Controllers
{
    public class WishlistController : Controller
    {
        //
        // GET: /Bestelling/

        //public list<Wishlistitems> Wishlist = new list<Wishlistitems>();
        WishlistItem wishlistitem;
        WishList wishlist;
        public ActionResult Index(WishList list)
        {
            this.wishlist = list;
            return View();
        }

        //Om een item te verwijderen
        public ActionResult DeleteItem(WishlistItem item)
        {

            this.wishlistitem = ;
            

            return View();
        }

        //Om een item uit de wishlist aan te passen
        public ActionResult EditItem(WishlistItem item)
        {
            //this.wishlistItem = item

            return View();
        }

        //Om naar de betaling te gaan
        public ActionResult Payment()
        {
            return View();
        }

        //Om de wishlist te laten zien
        public ActionResult ShowWishlist(List<WishlistItem> wishlist)
        {

            return View(wishlist);
        }


        //Om de wishlist op te slaan
        public ActionResult SaveWishlist()
        {
            return View();
        }

        public ActionResult RetrieveWishlist()
        {

            return View();
        }
    }
}