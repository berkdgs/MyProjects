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
    public class PositionController : Controller
    {
        // GET: Human/Position
        PositionService positionService;
        public PositionController()
        {
            positionService = new PositionService();
        }
        public ActionResult Index()
        {
            List<Position> positions = positionService.GetActive().OrderBy(x => x.Name).ToList();
            return View(positions);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Position position)
        {
            positionService.Add(position);
            return RedirectToAction("Index", "Position", new { area = "Human" });
        }
        public ActionResult Update(Guid id)
        {
            return View(positionService.GetById(id));
        }
        [HttpPost]
        public ActionResult Update(Position position)
        {
            positionService.Update(position);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid id)
        {
            positionService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}