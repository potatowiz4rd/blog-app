using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FA.JustBlog.UI.Controllers
{
    [Route("{controller}")]
    public class GalleryController : Controller
    {
        private readonly IUnitOfWork uow;
        public GalleryController(IUnitOfWork unitOfWork)
        {
            this.uow = unitOfWork;
        }
        public IActionResult Index()
        {
            var images = uow.ImageRepository.GetAll().ToList();

            return View(images);
        }
    }
}
