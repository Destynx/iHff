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
        public ActionResult Agenda()
        {
            ViewBag.Message = "De agenda van het IHFF";

            return View();
        }
        public ActionResult ShowActivity()
        {
            return View();
        }

        /*   
        public ActionResult ShowAgendaItems()
        {
            list<Product> AgendaList = DatabaseHandler.GetAllProductsList();
            Viewbag.AgendaList = AgendaList;

            return View();
        }
                      
        public ActionResult ShowLightbox(GeklikteItem)
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