using CST_Web.Data;
using CST_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSTWEB.Controllers
{
    public class EqclassController : Controller
    {
        private readonly ApplicationDBContext _context;
        public EqclassController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var eqclass = _context.Eqclasses.ToList();
            return View(eqclass);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Eqclass eqclass)
        {
            if (ModelState.IsValid)
            {
                _context.Eqclasses.Add(eqclass);
                _context.SaveChanges();
                TempData["Create"] = "Item has been Created";
                return RedirectToAction("Index");
            }
            return View(eqclass);

        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var eqclassindb = _context.Eqclasses.Find(Id);
            return View(eqclassindb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Eqclass eqclass)
        {
            if (ModelState.IsValid)
            {
                _context.Eqclasses.Update(eqclass);
                _context.SaveChanges();
                TempData["Update"] = "Item has been Update";
                return RedirectToAction("Index");
            }
            return View(eqclass);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var eqclassindb = _context.Eqclasses.Find(Id);
            return View(eqclassindb);
        }
        [HttpPost]
        public IActionResult DeleteClas(int? Id)
        {
            var eqclassindb = _context.Eqclasses.Find(Id);
            if (eqclassindb == null)
            {
                NotFound();
            }
            _context.Eqclasses.Remove(eqclassindb);
            _context.SaveChanges();
            TempData["Delete"] = "Item has been Delete";
            return RedirectToAction("Index");
        }
    }
}
