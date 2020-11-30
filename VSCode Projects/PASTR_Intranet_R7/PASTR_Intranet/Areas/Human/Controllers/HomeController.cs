using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using NTier.Core.Entity;
using NTier.Model;
using NTier.Model.Entities;
using NTier.Model.Validations;
using NTier.Service.Option;
using PASTR.Intranet.Utility;

namespace PASTR_Intranet.Areas.Human.Controllers
{
    //[Authorize(Roles = @"CER\Human Resources, CER\Domain Admins, LT252080\Administrators")]
    public class HomeController : Controller
    {
        // GET: Human/Home
        DepartmentService departmentService;
        PersonService personService;
        PositionService positionService;

        public HomeController()
        {
            departmentService = new DepartmentService();
            positionService = new PositionService();
            personService = new PersonService();
        }

        #region Methods
        public Dictionary<String, List<SelectListItem>> GetItems()
        {
            Dictionary<String, List<SelectListItem>> items = new Dictionary<string, List<SelectListItem>>();
            List<SelectListItem> department = departmentService.GetActive().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList().OrderBy(x => x.Text).ToList();

            List<SelectListItem> position = positionService.GetActive().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList().OrderBy(x => x.Text).ToList();
            items.Add("Department", department);
            items.Add("Position", position);
            return items;
        } 
        #endregion

        public ActionResult Index()
        {
            return View(personService.GetActive().OrderBy(x => x.Name).ToList());
        }

        public ActionResult Add()
        {
            TempData["Departments"] = GetItems()["Department"]; //  departments; //GetSelectListItem()["Departments"]; 
            TempData["Positions"] = GetItems()["Position"]; //GetSelectListItem()["Positions"]; 
            return View();
        }


        [HttpPost]
        public ActionResult Add(Person person, HttpPostedFileBase image)
        {
            person.ImagePath = ImageUploader.UploadImage("/images/Uploads/People/", image);
            if (person.ImagePath == "0" || person.ImagePath == "1" || person.ImagePath == "2")
                person.ImagePath = "/images/Uploads/People/user.jpg";
            PersonValidator validator = new PersonValidator();
            ValidationResult result = validator.Validate(person);

            if (!ModelState.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                TempData["Departments"] = GetItems()["Department"]; //GetSelectListItem()["Departments"]; 
                TempData["Positions"] = GetItems()["Position"]; //GetSelectListItem()["Positions"]; 

                return View();
            }

            personService.Add(person);
            return RedirectToAction("Index", "Home", new { area = "Human" });
        }

        public ActionResult Update(Guid id)
        {
            TempData["Departments"] = GetItems()["Department"];
            TempData["Positions"] = GetItems()["Position"];
            Person updateData = personService.GetById(id);
            return View(updateData);
        }
        [HttpPost]
        public ActionResult Update(Person person, HttpPostedFileBase image)
        {
            person.ImagePath = ImageUploader.UploadImage("/images/Uploads/People/", image);
            if (person.ImagePath == "0" || person.ImagePath == "1" || person.ImagePath == "2")
                person.ImagePath = "/images/Uploads/People/user.jpg";

            personService.Update(person);
            return RedirectToAction("Index", "Home", new { area = "Human" });
        }
        public ActionResult Delete(Guid id)
        {
            personService.Remove(id);
            return RedirectToAction("Index", "Home", new { area = "Human" });
        }
    }
}