using NTier.Maintenance.Model.Entities;
using NTier.Maintenance.Service.Optional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PASTR_Intranet.Areas.Maintenance.Controllers
{
    public class WorkerController : Controller
    {
        // GET: Maintenance/Worker
        WorkerService db;
        public WorkerController()
        {
            db = new WorkerService();
        }
        public ActionResult Index()
        {
            return View(db.GetActive());
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Worker worker)
        {
            db.Add(worker);
            return RedirectToAction("Index", "Worker", new { area = "Maintenance" });
        }
        public ActionResult Update(Guid id)
        {
            return View(db.GetById(id));
        }
        [HttpPost]
        public ActionResult Update(Worker worker)
        {
            db.Update(worker);
            return RedirectToAction("Index", "Worker", new { area = "Maintenance" });
        }
        public ActionResult Delete(Guid id)
        {
            db.Remove(id);
            return RedirectToAction("Index", "Worker", new { area = "Maintenance" });
        }
    }
}