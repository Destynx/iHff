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
            ViewBag.id = ID;

            return View(films);
        }
        public ActionResult Agenda()
        {
            ViewBag.Message = "De agenda van het IHFF";

            List<Product> AgendaList = DatabaseHandler.GetAllProducts();
            ViewBag.AgendaList = AgendaList;
            ViewBag.Day = "";

            return View();
        }

        /*
        public ActionResult GetItemInfo(GeklikteItem)
        {
            //Het tonen van een lightbox on click en het vullen van die lightbox met informatie uit de database            
            Product product = DatabaseHandler.GetProduct(GeklikteItem);

            return View(product);
        }
       
        
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