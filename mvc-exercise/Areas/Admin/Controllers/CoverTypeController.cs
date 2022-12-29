using Microsoft.AspNetCore.Mvc;
using Mvc_exercise.DataAccess;
using Mvc_exercise.DataAccess.Repository.IRepository;
using Mvc_exercise.Models;

namespace mvc_exercise.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CoverType.Add(obj);
                unitOfWork.Save();
                TempData["success"] = "CoverType created successfully";
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
            var coverType = unitOfWork.CoverType.GetFirstOrDeFault(u => u.Id == id);

            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CoverType.Update(obj);
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
            var coverType = unitOfWork.CoverType.GetFirstOrDeFault(u => u.Id == id);

            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = unitOfWork.CoverType.GetFirstOrDeFault(u => u.Id == id);
            if (obj == null) {
                return NotFound();
            }
            unitOfWork.CoverType.Remove(obj);
            unitOfWork.Save();
            return RedirectToAction("Index");                
        }
    }
}