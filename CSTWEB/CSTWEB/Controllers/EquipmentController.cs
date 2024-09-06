using CST_Web.Data;
using CST_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CST_Web.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly ApplicationDBContext _context;
        public EquipmentController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Equipments = _context.Equipments.Include(x => x.Categories).Include(x => x.EquipmentsFamily).Include(x => x.Eqclasses).Include(x => x.Departments).Include(x => x.Locations).ToList();
            //var Equipmentsfamily = _context.Equipments.Include(x=>x.EquipmentsFamily).ToList();
            return View(Equipments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = _context.Categories.Select(x => new
            {
                x.Id,
                x.Name,
                display = x.Name + " - " + x.Description,
            }).ToList();
            ViewBag.EquipmentFamily = _context.EquipmentsFamily.Select(x => new
            {
                x.Id,
                x.Name,
                display = x.Name,
            }).ToList();
            ViewBag.Eqclass = _context.Eqclasses.Select(x => new
            {
                x.Id,
                x.Name,
                display = x.Name,
            }).ToList();
            ViewBag.Department = _context.Departments.Select(x => new
            {
                x.Id,
                x.Name,
                display = x.Name,
            }).ToList();            
            ViewBag.Location = _context.Locations.Select(x => new
            {
                x.Id,
                x.Name,
                display = x.Name,
            }).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Equipments.Add(equipment);
                _context.SaveChanges();
                TempData["Create"] = "Item has been Created";
                return RedirectToAction("Index");
            }
            return View(equipment);

        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            ViewBag.Category = _context.Categories.Select(x => new
            {
                x.Id,
                x.Name,
                display = x.Name + " - " + x.Description,
            }).ToList();
            ViewBag.EquipmentFamily = _context.EquipmentsFamily.Select(x => new
            {
                x.Id,
                x.Name,
                display = x.Name,
            }).ToList();
            ViewBag.Eqclass = _context.Eqclasses.Select(x => new
            {
                x.Id,
                x.Name,
                display = x.Name,
            }).ToList();
            ViewBag.Department = _context.Departments.Select(x => new
            {
                x.Id,
                x.Name,
                display = x.Name,
            }).ToList();
            ViewBag.Location = _context.Locations.Select(x => new
            {
                x.Id,
                x.Name,
                display = x.Name,
            }).ToList();
            var Equipmentindb = _context.Equipments.Find(Id);
            return View(Equipmentindb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Equipments.Update(equipment);
                _context.SaveChanges();
                TempData["Update"] = "Item has been Update";
                return RedirectToAction("Index");
            }
            return View(equipment);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var Equipmentindb = _context.Equipments.Find(Id);
            return View(Equipmentindb);
        }
        [HttpPost]
        public IActionResult DeleteEquipment(int? Id)
        {
            var Equipmentindb = _context.Equipments.Find(Id);
            if (Equipmentindb == null)
            {
                NotFound();
            }
            _context.Equipments.Remove(Equipmentindb);
            _context.SaveChanges();
            TempData["Delete"] = "Item has been Delete";
            return RedirectToAction("Index");
        }
    }
}
