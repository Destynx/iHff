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
        public ActionResult Index()
        {
            return View();
        }

        //Om een item te verwijderen
        public ActionResult VerwijderItem(/*WishListItem item*/)
        {
            //this.WishListItem = WishListItem;
            
            return View();
        }

        //Om een item uit de wishlist aan te passen
        public ActionResult PasItemAan()
        {
            return View();
        }

        //Om naar de betaling te gaan
        public ActionResult Betaling()
        {
            return View();
        }

        //Om de wishlist te laten zien
        public ActionResult ShowWishlist()
        {
            return View();
        }
    }
}