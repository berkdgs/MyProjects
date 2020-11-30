using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PASTR_Intranet.Areas.Human.Controllers
{
    [Authorize(Roles =@"CER\Human Resources, CER\Domain Admins")]
    public class DepartmentController : Controller
    {
        // GET: Human/Department
        DepartmentService departmentService;
        public DepartmentController()
        {
            departmentService = new DepartmentService();
        }
        public ActionResult Index()
        {
            List<Department> departments = departmentService.GetActive().OrderBy(x => x.Name).ToList();
            return View(departments);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Department department)
        {
            departmentService.Add(department);
            return RedirectToAction("Index", "Department", new { area = "Human" });
        }
        public ActionResult Update(Guid id)
        {
            return View(departmentService.GetById(id));
        }

        [HttpPost]
        public ActionResult Update(Department department)
        {
            departmentService.Update(department);
            return RedirectToAction("Index", "Department", new { area = "Human" });
        }
        public ActionResult Delete(Guid id)
        {
            departmentService.Remove(id);
            return RedirectToAction("Index", "Department", new { area = "Human" });
        }
    }
}