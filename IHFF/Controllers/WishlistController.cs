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
        WishList wishlist = new WishList();

        public ActionResult Index()
        {
            wishlist = System.Web.HttpContext.Current.Session["wishlist"] as WishList;
            if (wishlist == null)
            {
                wishlist = new WishList { wishListCode = 0};
            }
            if (wishlist.wishListCode == 0)
            {
                wishlist.NewList();
            }
            return View(wishlist);
        }
        [HttpPost]
        public ActionResult Index(int wishListCode)
        {
            wishlist = DatabaseHandler.GetWishlist(wishListCode);
            System.Web.HttpContext.Current.Session["wishlist"] = wishlist;
            return View(wishlist);

        }
        
        public ActionResult clearWishlist()
        {
            wishlist = new WishList { wishListCode = (System.Web.HttpContext.Current.Session["wishList"] as WishList).wishListCode };
            DatabaseHandler.UpdateWishlist(wishlist);
            System.Web.HttpContext.Current.Session["wishlist"] = wishlist;
            return RedirectToAction("Index");
        }
        public ActionResult saveWishlist()
        {
            WishList wishlist = System.Web.HttpContext.Current.Session["wishlist"] as WishList;
            DatabaseHandler.AddWishlist(wishlist);
            return RedirectToAction("Index");
        }
        public ActionResult payWishlist(int? kees)
        {
            ViewBag.wishlist = wishlist = System.Web.HttpContext.Current.Session["wishlist"] as WishList;

            return View(wishlist);
        }
        [HttpPost]
        public ActionResult payWishlist()
        {
            wishlist.betaald = true;
            DatabaseHandler.PayWishlist(wishlist);
            return Redirect("http://www.ideal.com");
        }
    }
} 