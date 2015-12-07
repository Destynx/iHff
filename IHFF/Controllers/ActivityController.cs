using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class ActivityController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /* */

        public ActionResult ShowLightbox()
        {
            //Het tonen van een lightbox on click en het vullen van die lightbox met informatie uit de database
            return View();
        }


    }
}