using CST_Web.Data;
using CST_Web.Models;
using CSTWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSTWEB.Controllers
{
    public class SectionController : Controller
    {
        private readonly ApplicationDBContext _context;
        public SectionController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var sections = _context.Sections.Include(x => x.Departments).ToList();
            return View(sections);
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
        public IActionResult Create(Section section)
        {
            if (ModelState.IsValid)
            {
                _context.Sections.Add(section);
                _context.SaveChanges();
                TempData["Create"] = "Item has been Created";
                return RedirectToAction("Index");
            }
            return View(section);

        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var sectionindb = _context.Sections.Find(Id);
            return View(sectionindb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Section section)
        {
            if (ModelState.IsValid)
            {
                _context.Sections.Update(section);
                _context.SaveChanges();
                TempData["Update"] = "Item has been Update";
                return RedirectToAction("Index");
            }
            return View(section);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var sectionindb = _context.Sections.Find(Id);
            return View(sectionindb);
        }
        [HttpPost]
        public IActionResult DeleteSec(int? Id)
        {
            var sectionindb = _context.Sections.Find(Id);
            if (sectionindb == null)
            {
                NotFound();
            }
            _context.Sections.Remove(sectionindb);
            _context.SaveChanges();
            TempData["Delete"] = "Item has been Delete";
            return RedirectToAction("Index");
        }
    }
}
