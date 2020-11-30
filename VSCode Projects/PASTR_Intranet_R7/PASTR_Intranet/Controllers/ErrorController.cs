using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAS.Intranet.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult PageError()
        {
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult Page404(String aspxerrorpath)
        {
            if (!String.IsNullOrEmpty(aspxerrorpath))
                ViewBag.Kaynak = aspxerrorpath;
            else
                ViewBag.Kaynak = "Girmiş olduğunuz sayfa bulunamadı";

            
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
        public ActionResult Page403()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
        public ActionResult Page500()
        {
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
        public ActionResult PageNullData(String kaynak)
        {
            ViewBag.Kaynak = kaynak;
            return View("PageError");
        }
           
    }
}