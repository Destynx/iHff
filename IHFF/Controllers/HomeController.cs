using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;

namespace IHFF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult RetrieveWishlist(WishList code)
        {
            //Het opvragen van een eerder in de database opgeslagen WishList.
            if (ModelState.IsValid)
            {
                // WishList retrieveWishlist = **database connection.
                // If (WishlistCode == DatabaseCode)
                // { redirect to WishList page with all items}
                // Else 
                // { Message: Code incorrect probeer opnieuw }
                return View(code);
            }
            return RedirectToAction("~/Bestelling/...cshtml");
        }
    }
}