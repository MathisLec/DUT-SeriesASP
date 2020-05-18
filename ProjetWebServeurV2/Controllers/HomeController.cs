using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetWebServeurV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Accueil()
        {
            return View();
        }

        public ActionResult APropos()
        {
            return View();
        }
    }
}