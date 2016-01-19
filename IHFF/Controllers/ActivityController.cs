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

        public ActionResult ProductInfo(int ID)
        {
            Product films = DatabaseHandler.GetProduct(ID);
            WishlistItem wlitem = new WishlistItem { item = films };
            ViewBag.id = ID;
            ViewBag.film = films;
            return View(wlitem);
        }
        [HttpPost]
        public ActionResult ProductInfo(FormCollection form)
        {
            int id;
            int amount;
            amount = Convert.ToInt32(form["Aantal"]);
            id = Convert.ToInt32(form["hidden_id"]);

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

   

        public ActionResult AddToWishlist()
        {
            
            //Geselecteerde items lijst in de database zetten als Wishlist
            return View();
        }
    }
}