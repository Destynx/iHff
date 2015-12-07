using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class WishlistController : Controller
    {
        //
        // GET: /Bestelling/

        //public list<Wishlistitems> Wishlist = new list<Wishlistitems>();
        // WishListItem wishlistItem;
        //WishList wishlist;
        public ActionResult Index()
        {
            return View();
        }

        //Om een item te verwijderen
        public ActionResult DeleteItem(/*WishListItem item*/)
        {
            //this.wishlistItem = WishListItem;
            
            return View();
        }

        //Om een item uit de wishlist aan te passen
        public ActionResult EditItem(/*WishListItem item*/)
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
        public ActionResult ShowWishlist()
        {
            return View();
        }


        //Om de wishlist op te slaan
        public ActionResult SaveWishlist()
        {
            return View();
        }
    }
}