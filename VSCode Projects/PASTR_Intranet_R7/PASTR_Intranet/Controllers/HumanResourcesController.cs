using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAS.Intranet.Controllers
{
    public class HumanResourcesController : Controller
    {
        // GET: InsanKaynaklari
        PersonService humanService;
        public HumanResourcesController()
        {
            humanService = new PersonService();
        }
        public ActionResult Index()
        {
            List<Person> people = humanService.GetActive().OrderBy(x => x.Name).ToList();
            return View(people);
        }
    }
}