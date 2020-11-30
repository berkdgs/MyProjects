using NTier.Maintenance.Model.Entities;
using NTier.Maintenance.Model.Enums;
using NTier.Maintenance.Service.Optional;
using PASTR.Intranet.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace PASTR_Intranet.Areas.Maintenance.Controllers
{
    public class OperationController : BaseController
    {
        // GET: Maintenance/Operation
        OperationService operationService;
        MachineService machineService;
        WorkerService workerService;
        public OperationController()
        {
            operationService = new OperationService();
            machineService = new MachineService();
            workerService = new WorkerService();
        }

        public ActionResult Index()
        {
            return View(operationService.GetActive());
        }
        public ActionResult GetByMachine(Guid id)
        {
            TempData["Machine"] = machineService.GetById(id).Description;
            return View(operationService.GetByMachine(id));
        }
        public ActionResult GetByPerson(Guid id)
        {
            TempData["Person"] = workerService.GetById(id).LongName;
            return View(operationService.GetByPerson(id));
        }
        public ActionResult Add(Guid id)
        {
            if (!operationService.AnyOpenOperation(id))
            {
                TempData["Machine"] = machineService.GetById(id);
                return View();
            }
            else
            {
                ShowMessage(MessageType.Danger, "Açık bakım var. Bakım açma işlemi hata aldı. Bilgilerinizi kontrol ediniz!", 3, false);
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Add(Operation operation, String workerName)
        {
            operation.WorkerId = (workerService.GetByDefault(x => x.Name == workerName)).Id;

            if (!operationService.AnyOpenOperation(operation.MachineId))
            {
                operationService.Add(operation);
                ShowMessage(MessageType.Success, "Bakım açma işlemi başarı ile saklandı!", 3, true);
                return RedirectToAction("Index", "Operation", new { area = "Maintenance" });
            }
            else
            {
                TempData["Machine"] = machineService.GetById(operation.MachineId);
                ShowMessage(MessageType.Warning, "Açık bakım işlemi var. Bakım açma işlemi hata aldı! Bilgilerinizi kontrol ediniz!", 3, false);
                return View();
            }
        }
        public ActionResult Update(Guid id)
        {
            if (operationService.AnyOpenOperation(id))
            {
                return View(operationService.OpenOperation(id));
            }
            ShowMessage(MessageType.Warning, "Açık bakım bulunamadı. Bakım kapama işlemi hata aldı! Bilgilerinizi kontrol ediniz!", 60, true);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Update(Operation operation)
        {
            if (ModelState.IsValid)
            { 
                operationService.Update(operation);
                ShowMessage(MessageType.Success, "Bakım kapama işlemi başarı ile saklandı!", 3, true);
            }
            else
            {
                ShowMessage(MessageType.Danger, "Bakım kapama işlemi hata aldı! Bilgilerinizi kontrol ediniz", 60, true);
                return View(operationService.GetById(operation.Id));
            }
            return RedirectToAction("Index");
        }
    }
}