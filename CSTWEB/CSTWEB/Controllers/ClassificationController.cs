using CST_Web.Data;
using CST_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CST_Web.Controllers
{
    public class ClassificationController : Controller
    {
        private readonly ApplicationDBContext _context;
        public ClassificationController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var classifications = _context.Classifications.ToList();
            return View(classifications);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Classification classification)
        {
            if (ModelState.IsValid)
            {
                _context.Classifications.Add(classification);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classification);

        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var classificationindb = _context.Classifications.Find(Id);
            return View(classificationindb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Classification classification)
        {
            if (ModelState.IsValid)
            {
                _context.Classifications.Update(classification);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classification);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var classificationindb = _context.Classifications.Find(Id);
            return View(classificationindb);
        }
        [HttpPost]
        public IActionResult DeleteClas(int? Id)
        {
            var classificationindb = _context.Classifications.Find(Id);
            if (classificationindb == null)
            {
                NotFound();
            }
            _context.Classifications.Remove(classificationindb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
