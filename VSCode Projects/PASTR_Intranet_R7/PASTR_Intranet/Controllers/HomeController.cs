using NTier.Model.Entities;
using NTier.Service.Option;
using PASTR.Intranet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using PASTR.Intranet.Utility;

namespace PASTR.Intranet.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AylikMenu()
        {
            return View(Yemek(false));
        }

        public PartialViewResult GunlukMenu()
        {
            IEnumerable<YemekMenu> tablo = Yemek(true);
            return PartialView($"_GununMenusu", tablo);
        }
        public PartialViewResult GunlukKur()
        {
            
            string todayTCMB = @"http://www.tcmb.gov.tr/kurlar/today.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(todayTCMB);

            string KurTarihi = xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value;
            string USD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexSelling").InnerXml;
            string EUR = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/ForexSelling").InnerXml;
            string GBP = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/ForexSelling").InnerXml;
            List<string> kurlar = new List<string>() { USD, EUR, GBP };
            ViewBag.Tarih = KurTarihi; 
            return PartialView($"_TCMBDoviz", kurlar);
        }

        public PartialViewResult DogumGunu()
        {
            PersonService personService = new PersonService();
            List<Person> bugunDoganlar = personService.GetBirthDays();

            return PartialView($"_DogumGunu", bugunDoganlar);
        }
    }
}