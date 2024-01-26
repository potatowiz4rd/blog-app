using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork uow;
        public CategoryController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public IActionResult Index()
        {
            //ViewBag.Categories = uow.CategoryRepository.GetAll();
            var result = uow.CategoryRepository.GetAll();
            return View("~/Views/Shared/_Layout.cshtml", result);
        }
    }
}
