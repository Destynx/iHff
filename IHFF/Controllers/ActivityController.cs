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
            WishList wishlist = new WishList();
            int amount = Convert.ToInt32(Form["Aantal"]);
            int id = Convert.ToInt32(Form["hidden_id"]);

            if (System.Web.HttpContext.Current.Session["wishlist"] == null)
            {
                wishlist.NewList();
                System.Web.HttpContext.Current.Session["wishlist"] = wishlist;
            }
            else
            {
                wishlist = DatabaseHandler.GetWishlist((System.Web.HttpContext.Current.Session["wishlist"] as WishList).wishListCode);
            }

            bool checkExists = false;

            foreach(WishlistItem wi in wishlist.itemList)
            {
                if (wi.item.ID == id)
                {
                    wi.Aantal += amount;
                    checkExists = true;
                    break;
                }
            }

            if (!checkExists)
            {
                wishlist.itemList.Add(new WishlistItem(id, amount));
            }


            
            return View(id);
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
            List<Product> AgendaList = DatabaseHandler.GetAllProducts();
            ViewBag.AgendaList = AgendaList;
            //List<Restaurant> RestaurantList = DatabaseHandler.GetAllRestaurants();
            //ViewBag.RestaurantList = RestaurantList;
            return View();
        }

        public ActionResult RestaurantInfo(int ID)
        {
            Product restaurant = DatabaseHandler.GetProduct(ID);
            WishlistItem wlitem = new WishlistItem { item = restaurant };
            ViewBag.id = ID;
            ViewBag.restaurant = restaurant;
            return View(wlitem);
        }



        public ActionResult AddToWishlist()
        {
            
            //Geselecteerde items lijst in de database zetten als Wishlist
            return View();
        }
    }
}