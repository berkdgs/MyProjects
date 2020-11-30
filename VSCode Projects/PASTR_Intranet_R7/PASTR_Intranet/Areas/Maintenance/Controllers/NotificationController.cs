using NTier.Maintenance.Service.Optional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NTier.Maintenance.Model.Entities;

namespace PASTR_Intranet.Areas.Maintenance.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Maintenance/Notification
        private readonly NotificationService _notificationService;
        private readonly MachineService _machineService;
        public NotificationController()
        {
            _notificationService = new NotificationService();
            _machineService = new MachineService();
        }
        public ActionResult Index()
        {
            return View(_notificationService.GetActive());
        }
        public ActionResult Add()
        {
            List<SelectListItem> machines = _machineService.GetActive().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text =  x.Name
            }).ToList();
            ViewBag.MachineList = machines;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Notification entity)
        {
            _notificationService.Add(entity);
            return RedirectToAction("Index");
        }
    }
}