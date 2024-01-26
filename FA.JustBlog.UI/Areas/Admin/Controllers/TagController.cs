using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FA.JustBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private IUnitOfWork uow;

        public TagController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public IActionResult Tags()
        {
            var result = uow.TagRepository.GetAll();
            return View(result.ToList());
        }


        [HttpGet]
        public IActionResult Detail(int id)
        {
            var result = uow.TagRepository.Find(id);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tag tag)
        {

            uow.TagRepository.Create(tag);
            uow.SaveChanges();

            return RedirectToAction("Tags");

        }

        public IActionResult Edit(int? id)
        {

            if (id.HasValue)
            {
                var tag = uow.TagRepository.Find(id);

                return View(tag);
            }
            return RedirectToAction("Tags");

        }
        [HttpPost]
        public IActionResult Edit(int? id, Tag tag)
        {
            if (ModelState.IsValid)
            {
                uow.TagRepository.Update(tag);
                uow.SaveChanges();
                return RedirectToAction("Tags");
            }
            return View(tag);
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var tag = uow.TagRepository.Find(id);

                return View(tag);
            }
            return RedirectToAction("Tags");

        }
        [HttpPost]
        public IActionResult Delete(int? id, Tag tag)
        {
            try
            {
                tag = uow.TagRepository.Find(id);
                uow.TagRepository.Delete(tag);
                uow.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Tags");
        }
    }
}
