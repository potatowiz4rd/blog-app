using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FA.JustBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork uow;

        public CategoryController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IActionResult Categories()
        {
            var result = uow.CategoryRepository.GetAll();
            return View(result.ToList());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var result = uow.CategoryRepository.Find(id);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {

            uow.CategoryRepository.Create(category);
            uow.SaveChanges();

            return RedirectToAction("Categories");

        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var category = uow.CategoryRepository.Find(id);

                return View(category);
            }
            return RedirectToAction("Categories");

        }
        [HttpPost]
        public IActionResult Edit(int? id, Category category)
        {
            if (ModelState.IsValid)
            {
                uow.CategoryRepository.Update(category);
                uow.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View(category);
        }

        //[HttpPost]
        //public IActionResult Delete(int? id)
        //{
        //    var category = uow.CategoryRepository.Find(id);
        //    uow.CategoryRepository.Delete(category);
        //    uow.SaveChanges();
        //    return RedirectToAction("Categories");
        //}

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var category = uow.CategoryRepository.Find(id);

                return View(category);
            }
            return RedirectToAction("Categories");

        }
        [HttpPost]
        public IActionResult Delete(int? id, Category category)
        {
            try
            {
                category = uow.CategoryRepository.Find(id);
                uow.CategoryRepository.Delete(category);
                uow.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Categories");
        }

    }
}
