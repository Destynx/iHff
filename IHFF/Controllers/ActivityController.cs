using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Classes;
using IHFF.Models;

namespace IHFF.Controllers
{
    public class ActivityController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductInfo(int ID)
        {
            Product films = DatabaseHandler.GetProduct(ID);
            WishlistItem wlitem = new WishlistItem { item = films };
            ViewBag.id = ID;
            ViewBag.film = films;
            return View(wlitem);
        }
        [HttpPost]
        public ActionResult ProductInfo(FormCollection Form, WishList wl)
        {
            WishlistItem wli = new WishlistItem();
            WishList wishlist = new WishList();
            int amount = Convert.ToInt32(Form["Aantal"]);
            int id = Convert.ToInt32(Form["hidden_id"]);

            if (System.Web.HttpContext.Current.Session["wishlist"] != null)
            {
                wishlist = DatabaseHandler.GetWishlist((System.Web.HttpContext.Current.Session["wishlist"] as WishList).wishListCode);
                foreach (WishlistItem wlitem in wishlist.itemList)
                {
                    if (wlitem.item.ID == id)
                    {
                        wlitem.Aantal = amount;
                        wli = wlitem;
                        wli.item.Locatie = DatabaseHandler.GetLocatie(wli.item.Locatie.Locatie_ID);
                    }
                }
            }
            else
            {
                wli = new WishlistItem { item = DatabaseHandler.GetProduct(id), Aantal = amount };
                wishlist.itemList.Add(wli);
            }
            System.Web.HttpContext.Current.Session["wishlist"] = wishlist;
            return View(wli);
        }
        public ActionResult Agenda()
        {
            ViewBag.Message = "De agenda van het IHFF";

            List<Product> AgendaList = DatabaseHandler.GetAllProducts();
            ViewBag.AgendaList = AgendaList;
            ViewBag.Day = "";

            return View();
        }

        public ActionResult RestaurantAgenda()
        {
            List<Product> RestaurantList = DatabaseHandler.GetAllRestaurants();
            ViewBag.RestaurantList = RestaurantList;
            return View();
        }

   

        public ActionResult AddToWishlist()
        {
            
            //Geselecteerde items lijst in de database zetten als Wishlist
            return View();
        }
    }
}