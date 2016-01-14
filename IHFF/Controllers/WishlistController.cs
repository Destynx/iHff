using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using IHFF.Classes;
using System.Web.Security;

namespace IHFF.Controllers
{
    public class WishlistController : Controller
    {
        //
        // GET: /Bestelling/

        WishlistItem wishlistitem;
        WishList wishlist;
        int code;
        private object session;

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(WishlistModel model)
        {
            int code = int.Parse(model.code);
            this.wishlist = DatabaseHandler.GetWishlist(code);
            if (session != null)
            {
            FormsAuthentication.SetAuthCookie(wishlist.wishListCode.ToString(), false);
            Session["loggedin_account"] = session;
                //session.wishlistCode = wishlist.wishListCode();
            }
            return View(wishlist.itemList);

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
        public ActionResult Payment()
        {
            wishlist.betaald = true;
            DatabaseHandler.UpdateWishlist(wishlist);
            return View();
        }

        //Om de wishlist op te slaan
        public ActionResult SaveWishlist(WishList wishlist)
        {
            
            DatabaseHandler.UpdateWishlist(wishlist);
            return View(); 

        }
        //Om de wishlist op te halen uit de database en te laten zien op de wishlistpagina
        public ActionResult RetrieveWishlist(string tekst)
        {
            int code = int.Parse(tekst);
            this.wishlist = DatabaseHandler.GetWishlist(code);
            return View(wishlist.itemList);
        }
    }
}