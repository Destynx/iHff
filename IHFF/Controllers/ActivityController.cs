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
        public ActionResult ProductInfo(WishList wl)
        {
            WishList wishlist = new WishList();
            int amount = Convert.ToInt32(form["Aantal"]);
            int id = Convert.ToInt32(form["hidden_id"]);

            if (Session["wishlist"] == null)
            {
                wishlist.NewList();
                Session["wishlist"] = wishlist;
            }
            else
            {
                wishlist = DatabaseHandler.GetWishlist(Convert.ToInt32(Session["wishlist"]));
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


            
            return View();
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
            List<Restaurant> RestaurantList = DatabaseHandler.GetAllRestaurants();
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