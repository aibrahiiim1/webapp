using CST_Web.Data;
using CST_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CST_Web.Controllers
{
    public class EquipmentFamilyController : Controller
    {
        private readonly ApplicationDBContext _context;
        public EquipmentFamilyController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var equipmentsfamily = _context.EquipmentsFamily.ToList();
            return View(equipmentsfamily);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EquipmentFamily equipmentsfamily)
        {
            if (ModelState.IsValid)
            {
                _context.EquipmentsFamily.Add(equipmentsfamily);
                _context.SaveChanges();
                TempData["Create"] = "Item has been Created";
                return RedirectToAction("Index");
            }
            return View(equipmentsfamily);

        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var equipmentsfamilyindb = _context.EquipmentsFamily.Find(Id);
            return View(equipmentsfamilyindb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EquipmentFamily equipmentsfamily)
        {
            if (ModelState.IsValid)
            {
                _context.EquipmentsFamily.Update(equipmentsfamily);
                _context.SaveChanges();
                TempData["Update"] = "Item has been Update";
                return RedirectToAction("Index");
            }
            return View(equipmentsfamily);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var equipmentsfamilyindb = _context.EquipmentsFamily.Find(Id);
            return View(equipmentsfamilyindb);
        }
        [HttpPost]
        public IActionResult Deleteequfamily(int? Id)
        {
            var equipmentsfamilyindb = _context.EquipmentsFamily.Find(Id);
            if (equipmentsfamilyindb == null)
            {
                NotFound();
            }
            _context.EquipmentsFamily.Remove(equipmentsfamilyindb);
            _context.SaveChanges();
            TempData["Delete"] = "Item has been Delete";
            return RedirectToAction("Index");
        }
    }
}
