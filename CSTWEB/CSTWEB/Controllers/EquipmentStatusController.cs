using CST_Web.Data;
using CST_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CST_Web.Controllers
{
    public class EquipmentStatusController : Controller
    {
        private readonly ApplicationDBContext _context;
        public EquipmentStatusController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var equipmentsstatus = _context.EquipmentsStatus.ToList();
            return View(equipmentsstatus);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EquipmentStatus equipmentsstatus)
        {
            if (ModelState.IsValid)
            {
                _context.EquipmentsStatus.Add(equipmentsstatus);
                _context.SaveChanges();
                TempData["Create"] = "Item has been Created";
                return RedirectToAction("Index");
            }
            return View(equipmentsstatus);

        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var equipmentsstatusindb = _context.EquipmentsStatus.Find(Id);
            return View(equipmentsstatusindb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EquipmentStatus equipmentsstatus)
        {
            if (ModelState.IsValid)
            {
                _context.EquipmentsStatus.Update(equipmentsstatus);
                _context.SaveChanges();
                TempData["Update"] = "Item has been Update";
                return RedirectToAction("Index");
            }
            return View(equipmentsstatus);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var equipmentsstatusindb = _context.EquipmentsStatus.Find(Id);
            return View(equipmentsstatusindb);
        }
        [HttpPost]
        public IActionResult Deleteequstatus(int? Id)
        {
            var equipmentsstatusindb = _context.EquipmentsStatus.Find(Id);
            if (equipmentsstatusindb == null)
            {
                NotFound();
            }
            _context.EquipmentsStatus.Remove(equipmentsstatusindb);
            _context.SaveChanges();
            TempData["Delete"] = "Item has been Delete";
            return RedirectToAction("Index");
        }
    }
}
