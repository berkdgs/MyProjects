using NTier.Maintenance.Model.Entities;
using NTier.Maintenance.Service.Optional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PASTR_Intranet.Areas.Maintenance.Controllers
{
    public class MachineController : Controller
    {
        MachineService db;
        public MachineController()
        {
            db = new MachineService();
        }
        // GET: Maintenance/Machine
        public ActionResult Index()
        {
            return View(db.GetActive());
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Machine machine)
        {
            db.Add(machine);
            return RedirectToAction("Index", "Machine", new { area = "Maintenance" });
        }
        public ActionResult Update(Guid id)
        {
            return View(db.GetById(id));
        }
        [HttpPost]
        public ActionResult Update(Machine machine)
        {
            db.Update(machine);
            return RedirectToAction("Index", "Machine", new { area = "Maintenance" });
        }
        public ActionResult Delete(Guid id)
        {
            db.Remove(id);
            return RedirectToAction("Index", "Machine", new { area = "Maintenance" });
        }
    }
}