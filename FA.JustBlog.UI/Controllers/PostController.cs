using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace FA.JustBlog.UI.Controllers
{
    [Route("{controller}")]
    public class PostController : Controller
    {
        private readonly IUnitOfWork uow;
        public PostController(IUnitOfWork unitOfWork)
        {
            this.uow = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //ViewBag.Categories = uow.CategoryRepository.GetAll().ToList();
            var posts = uow.PostRepository.GetAll();

            return View(posts.ToList());
        }

        [Route("detail/{year}/{month}/{title}")]
        public IActionResult Detail(int year, int month, string title)
        {
            var result = uow.PostRepository.GetPostByCondition(year, month, title);
            result.Comments = uow.CommentRepository.GetCommentForPost(result.Id).ToList();
            var images = uow.ImageRepository.GetImagesForPost(result).ToList();

            ViewBag.Images = images; // Pass the images to the view using ViewBag

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            comment.CommentTime = DateTime.Now;
            uow.CommentRepository.Create(comment);
            await uow.SaveChangesAsync();

            var updatedComments = uow.CommentRepository.GetCommentForPost(comment.PostId).ToList();
            return PartialView("_CommentSection", updatedComments);
        }

        [Route("Category/{name}")]
        public IActionResult GetPostsByCategory(string name)
        {
            ViewBag.CategoryName = name;
            var result = uow.PostRepository.GetPostsByCategory(name);
            return View(result);
        }

        [Route("Tag/{name}")]
        public IActionResult GetPostsByTag(string name)
        {
            ViewBag.TagName = name;
            var result = uow.PostRepository.GetPostsByTag(name);
            return View(result);
        }
    }
}
