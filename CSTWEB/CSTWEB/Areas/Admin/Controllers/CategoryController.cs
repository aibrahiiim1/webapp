using CST_Web.Data;
using CST_Web.Models;
using CSTWEB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSTWEB.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //private readonly ApplicationDBContext _context;
        //public CategoryController(ApplicationDBContext context)
        //{
        //    _context = context;
        //}
        public IActionResult Index()
        {
            //var categories = _unitOfWork.Category.GetAll();
            return View();
            //var categories = _context.Categories.ToList();
            //return View(categories);
        }        
        public IActionResult GetData()
        {
            var categories = _unitOfWork.Category.GetAll();
            return Json(new { data = categories });
            //var categories = _context.Categories.ToList();
            //return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //_context.Categories.Add(category);
                _unitOfWork.Category.Add(category);
                //_context.SaveChanges();
                _unitOfWork.Complete();
                TempData["Create"] = "Item has been Created";
                return RedirectToAction("Index");
            }
            return View(category);

        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            //var categoryindb = _context.Categories.Find(Id);
            var categoryindb = _unitOfWork.Category.GetFirstorDefault(x => x.Id == Id);
            return View(categoryindb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                //_context.Categories.Update(category);
                _unitOfWork.Category.Update(category);
                //_context.SaveChanges();
                _unitOfWork.Complete();
                TempData["Update"] = "Item has been Update";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null | Id == 0)
            {
                NotFound();
            }
            //var categoryindb = _context.Categories.Find(Id);
            var categoryindb = _unitOfWork.Category.GetFirstorDefault(x => x.Id == Id);
            return View(categoryindb);
        }
        [HttpPost]
        public IActionResult DeleteCat(int? Id)
        {
            //var categoryindb = _context.Categories.Find(Id);
            var categoryindb = _unitOfWork.Category.GetFirstorDefault(x => x.Id == Id);
            if (categoryindb == null)
            {
                NotFound();
            }
            //_context.Categories.Remove(categoryindb);
            _unitOfWork.Category.Remove(categoryindb);
            //_context.SaveChanges();
            _unitOfWork.Complete();
            TempData["Delete"] = "Item has been Delete";
            return RedirectToAction("Index");
        }
    }
}
