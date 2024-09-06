using CST_Web.Data;
using CST_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace CST_Web.Controllers
{
    public class OrderStatusController : Controller
    {
        private readonly ApplicationDBContext _context;
        public OrderStatusController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //var ordersstatus = _context.OrdersStatus.ToList();
            return View();
        }        
        public IActionResult GetData()
        {
            var ordersstatus = _context.OrdersStatus.ToList();
            return Json(new { data = ordersstatus });
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderStatus orderstatus)
        {
            if (ModelState.IsValid)
            {
                _context.OrdersStatus.Add(orderstatus);
                _context.SaveChanges();
                TempData["Create"] = "Item has been Created";
                return RedirectToAction("Index");
            }
            return View(orderstatus);

        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var orderstatusindb = _context.OrdersStatus.Find(Id);
            return View(orderstatusindb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderStatus orderstatus)
        {
            if (ModelState.IsValid)
            {
                _context.OrdersStatus.Update(orderstatus);
                _context.SaveChanges();
                TempData["Update"] = "Item has been Update";
                return RedirectToAction("Index");
            }
            return View(orderstatus);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var orderstatusindb = _context.OrdersStatus.Find(Id);
            return View(orderstatusindb);
        }
        [HttpPost]
        public IActionResult Deleteordstatus(int? Id)
        {
            var orderstatusindb = _context.OrdersStatus.Find(Id);
            if (orderstatusindb == null)
            {
                NotFound();
            }
            _context.OrdersStatus.Remove(orderstatusindb);
            _context.SaveChanges();
            TempData["Delete"] = "Item has been Delete";
            return RedirectToAction("Index");
        }
    }
}
