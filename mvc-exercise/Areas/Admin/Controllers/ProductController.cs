using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc_exercise.DataAccess;
using Mvc_exercise.DataAccess.Repository.IRepository;
using Mvc_exercise.Models;
using Mvc_exercise.Models.ViewModels;

namespace mvc_exercise.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = unitOfWork.Product.GetAll();
            return View(objProductList);
        }

        public IActionResult Upsert(int? id)
        {
            ProductViewModel productVM = new()
            {
                Product = new(),
                CategoryList = unitOfWork.Category.GetAll().Select( u => new SelectListItem{
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),

                CoverTypeList = unitOfWork.CoverType.GetAll().Select( u => new SelectListItem{
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),               
            };


            if (id == null || id == 0)
            {
                // ViewBag.CategoryList = CategoryList;
                // ViewData["CoverTypeList"] = CoverTypeList;
                return View(productVM);
            }
            else{

            }

            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product obj)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Product.Update(obj);
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
            var Product = unitOfWork.Product.GetFirstOrDeFault(u => u.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = unitOfWork.Product.GetFirstOrDeFault(u => u.Id == id);
            if (obj == null) {
                return NotFound();
            }
            unitOfWork.Product.Remove(obj);
            unitOfWork.Save();
            return RedirectToAction("Index");                
        }
    }
}