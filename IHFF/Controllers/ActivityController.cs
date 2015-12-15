using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class ActivityController : Controller
    {
        public ActionResult ShowActivity()
        {
            return View();
        }

        /* */

        public ActionResult ShowLightbox()
        {
            //Het tonen van een lightbox on click en het vullen van die lightbox met informatie uit de database
            return View();
        }

        public ActionResult AddToSelectedItemslist()
        {
            //Door het klikken op de knop in de lightbox moet via hier het aangeklikte item naar de geselecteerde items lijst
            return View();
        }

        public ActionResult AddToWishlist()
        {
            //Geselecteerde items lijst in de database zetten als Wishlist + Generen van een unieke code
            return View();
        }

        [HttpPost]
        public ActionResult AddToWishlist1()
        {
            //Een redirect naar de wishlist pagina nadat er op de "toevoegen aan wishlist" is geklikt
            return View(/* Ga naar Wishlist-Pagina*/ );
        }
    }
}