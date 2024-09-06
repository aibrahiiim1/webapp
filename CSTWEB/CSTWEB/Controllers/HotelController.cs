using CST_Web.Data;
using CST_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CST_Web.Controllers
{
    public class HotelController : Controller
    {

        private readonly ApplicationDBContext _context;
        public HotelController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var hotels = _context.Hotels.ToList();
            return View(hotels);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Hotels.Add(hotel);
                _context.SaveChanges();
                TempData["Create"] = "Item has been Created";
                return RedirectToAction("Index");
            }
            return View(hotel);
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var hotelindb = _context.Hotels.Find(Id);
            return View(hotelindb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Hotels.Update(hotel);
                _context.SaveChanges();
                TempData["Update"] = "Item has been Update";
                return RedirectToAction("Index");
            }
            return View(hotel);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var hotelindb = _context.Hotels.Find(Id);
            return View(hotelindb);
        }
        [HttpPost]
        public IActionResult DeleteHot(int? Id)
        {
            var hotelindb = _context.Hotels.Find(Id);
            if (hotelindb == null)
            {
                NotFound();
            }
            _context.Hotels.Remove(hotelindb);
            _context.SaveChanges();
            TempData["Delete"] = "Item has been Delete";
            return RedirectToAction("Index");
        }
    }

}
