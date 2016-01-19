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
        public ActionResult Agenda()
        {
            ViewBag.Message = "De agenda van het IHFF";

            List<Product> AgendaList = DatabaseHandler.GetAllProducts();
            ViewBag.AgendaList = AgendaList;
            ViewBag.Day = "";

            return View();
        }

        public ActionResult RestaurantOverzicht()
        {
            List<Restaurant> RestaurantList = DatabaseHandler.
            ViewBag.RestaurantList = RestaurantList;            
            return View();
        }
        
        public ActionResult RestautantInfo(int ID)
        {
            Restaurant restaurant = DatabaseHandler.GetRestaurant(ID);
            WishlistItem wlitem = new WishlistItem { item = restaurant };
            ViewBag.idR = ID;
            ViewBag.restaurant = restaurant;
            return View(wlitem);
        }

        /*
        public ActionResult AddToItemslist(productID) //Toevoegen aan de geselecteerde itemslijst op de pagina
        {
            //Door het klikken op de knop in de lightbox moet via hier het aangeklikte item naar de geselecteerde items lijst
            List<Product> selectedItemsList = new List<Product>();

            Product product = DatabaseHandler.GetProduct(productID);
            selectedItemsList.Add(product);
            ViewBag.selectedItemsList = selectedItemsList;

            return View();
        }
        */

        public ActionResult AddToWishlist()
        {
            
            //Geselecteerde items lijst in de database zetten als Wishlist
            return View();
        }
    }
}