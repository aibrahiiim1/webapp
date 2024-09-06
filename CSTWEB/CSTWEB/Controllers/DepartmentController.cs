using CST_Web.Data;
using CST_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CST_Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDBContext _context;
        public DepartmentController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                TempData["Create"] = "Item has been Created";
                return RedirectToAction("Index");
            }
            return View(department);

        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var departmentindb = _context.Departments.Find(Id);
            return View(departmentindb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                TempData["Update"] = "Item has been Update";
                return RedirectToAction("Index");
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            var departmentindb = _context.Departments.Find(Id);
            return View(departmentindb);
        }
        [HttpPost]
        public IActionResult DeleteDep(int? Id)
        {
            var departmentindb = _context.Departments.Find(Id);
            if (departmentindb == null)
            {
                NotFound();
            }
            _context.Departments.Remove(departmentindb);
            _context.SaveChanges();
            TempData["Delete"] = "Item has been Delete";
            return RedirectToAction("Index");
        }
    }
}
