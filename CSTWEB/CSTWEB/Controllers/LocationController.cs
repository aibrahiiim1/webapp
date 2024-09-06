using CST_Web.Data;
using CST_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CST_Web.Controllers
{
    public class LocationController : Controller
    {
        private readonly ApplicationDBContext _context;
        public LocationController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Locations = _context.Locations.Include(x => x.Departments).ToList();
            return View(Locations);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Department = _context.Departments.Select(x => new
            {
                x.Id,
                x.Name,
                display = x.Name,
            }).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Locations.Add(location);
                _context.SaveChanges();
                TempData["Create"] = "Item has been Created";
                return RedirectToAction("Index");
            }
            return View(location);

        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            ViewBag.Department = _context.Departments.Select(x => new
            {
                x.Id,
                x.Name,
                display = x.Name,
            }).ToList();
            var Locationindb = _context.Locations.Find(Id);
            return View(Locationindb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Locations.Update(location);
                _context.SaveChanges();
                TempData["Update"] = "Item has been Update";
                return RedirectToAction("Index");
            }
            return View(location);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var Locationindb = _context.Locations.Find(Id);
            return View(Locationindb);
        }
        [HttpPost]
        public IActionResult DeleteLocation(int? Id)
        {
            var Locationindb = _context.Locations.Find(Id);
            if (Locationindb == null)
            {
                NotFound();
            }
            _context.Locations.Remove(Locationindb);
            _context.SaveChanges();
            TempData["Delete"] = "Item has been Delete";
            return RedirectToAction("Index");
        }
    }
}
