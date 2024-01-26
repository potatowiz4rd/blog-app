using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA.JustBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IWebHostEnvironment webHostEnvironment;

        public GalleryController(IUnitOfWork uow, IWebHostEnvironment webHostEnvironment)
        {
            this.uow = uow;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Gallery()
        {
            var result = uow.ImageRepository.GetAll();
            return View(result.ToList());
        }

        public IActionResult Create()
        {
            var posts = uow.PostRepository.GetAll().ToList();
            ViewBag.Posts = new SelectList(posts, "Id", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Image image)
        {
            var posts = uow.PostRepository.GetAll().ToList();
            ViewBag.Posts = new SelectList(posts, "Id", "Title");
            if (ModelState.IsValid)
            {
                // Save the file
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];

                    // Generate a unique filename
                    var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(file.FileName);
                    var filePath = System.IO.Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    // Set the image properties
                    image.FileName = fileName;
                    image.FilePath = "/images/" + fileName;
                }

                // Save the image to the repository
                uow.ImageRepository.Create(image);
                uow.SaveChanges();

                return RedirectToAction("Gallery");
            }

            // In case of validation errors, reload the view
            return View(image);
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var image = uow.ImageRepository.Find(id);

                return View(image);
            }
            return RedirectToAction("Gallery");

        }
        [HttpPost]
        public IActionResult Delete(int? id, Image image)
        {
            image = uow.ImageRepository.Find(id);

            if (image == null)
            {
                return NotFound();
            }

            // Delete the physical image file
            var filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", image.FileName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            // Delete the image from the repository
            uow.ImageRepository.Delete(image);
            uow.SaveChanges();

            return RedirectToAction("Gallery");
        }

    }
}
