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
        public ActionResult ShowLightbox(Geklikte Item)
        {
            
            //Het tonen van een lightbox on click en het vullen van die lightbox met informatie uit de database
            Product product = DatabaseHandler.GetProduct(Geklikte Item);
            
            return View(product);                                                
        }
        */

        public ActionResult AddToItemslist(/*productID*/)
        {
            //Door het klikken op de knop in de lightbox moet via hier het aangeklikte item naar de geselecteerde items lijst


            return View();
        }

        public ActionResult AddToWishlist()
        {
            
            //Geselecteerde items lijst in de database zetten als Wishlist
            return View();
        }
    }
}