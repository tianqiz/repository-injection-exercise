using Microsoft.AspNetCore.Mvc;
using Mvc_exercise.DataAccess;
using Mvc_exercise.DataAccess.Repository.IRepository;
using Mvc_exercise.Models;

namespace mvc_exercise.Controllers
{   
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = unitOfWork.Category.GetAll();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.DisplayOrder.ToString() == obj.Name)
            {
                ModelState.AddModelError("Name", "DisplayOrder cannot be equal to name");
            }
            if (ModelState.IsValid)
            {
                unitOfWork.Category.Add(obj);
                unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");                
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = unitOfWork.Category.GetFirstOrDeFault(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if(obj.DisplayOrder.ToString() == obj.Name)
            {
                ModelState.AddModelError("Name", "DisplayOrder cannot be equal to name");
            }
            if (ModelState.IsValid)
            {
                unitOfWork.Category.Update(obj);
                unitOfWork.Save();
                return RedirectToAction("Index");                
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = unitOfWork.Category.GetFirstOrDeFault(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = unitOfWork.Category.GetFirstOrDeFault(u => u.Id == id);
            if (obj == null) {
                return NotFound();
            }
            unitOfWork.Category.Remove(obj);
            unitOfWork.Save();
            return RedirectToAction("Index");                
        }
    }
}