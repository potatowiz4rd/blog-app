using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Service.tag;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using System.Data;

namespace FA.JustBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PostController(IUnitOfWork uow, IWebHostEnvironment webHostEnvironment)
        {
            this.uow = uow;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Posts()
        {
            var result = uow.PostRepository.GetAll();
            return View(result.ToList());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var result = uow.PostRepository.Find(id);
            return View(result);
        }

        public IActionResult Create()
        {
            var tags = uow.TagRepository.GetAll().ToList();
            ViewBag.Tags = tags; // Pass the tags to the view   
            ViewBag.CategoryId = new SelectList(uow.CategoryRepository.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(Post post, int[] Tags)
        {
            // Set the current time as the PostedOn value
            post.PostedOn = DateTime.Now;

            // Add the selected tags to the post
            foreach (var tagId in Tags)
            {
                post.PostTagMaps.Add(new PostTagMap { PostId = post.Id, TagId = tagId });
            }

            uow.PostRepository.Create(post);
            uow.SaveChanges();

            // Update the tag counts
            foreach (var tagId in Tags)
            {
                var tag = uow.TagRepository.Find(tagId);
                if (tag != null)
                {
                    tag.Count++;
                    uow.TagRepository.Update(tag);
                }
            }
            uow.SaveChanges();

            return RedirectToAction("Posts");
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.CategoryId = new SelectList(uow.CategoryRepository.GetAll(), "Id", "Name");

            if (id.HasValue)
            {
                var post = uow.PostRepository.Find(id);

                // Get all tags
                var tags = uow.TagRepository.GetAll().ToList();

                // Get the selected tags for the post
                var selectedTags = post.PostTagMaps.Select(ptm => ptm.TagId).ToList();

                // Pass the tags and selected tags to the view
                ViewBag.Tags = tags;
                ViewBag.SelectedTags = selectedTags;

                return View(post);
            }

            return RedirectToAction("Posts");
        }

        [HttpPost]
        public IActionResult Edit(int? id, Post post, int[] Tags)
        {
            if (ModelState.IsValid)
            {
                // Set the current time as the PostedOn value
                post.PostedOn = DateTime.Now;

                // Clear existing tags for the post
                post.PostTagMaps.Clear();

                // Add the selected tags to the post
                foreach (var tagId in Tags)
                {
                    post.PostTagMaps.Add(new PostTagMap { PostId = post.Id, TagId = tagId });
                }

                uow.PostRepository.Update(post);
                uow.SaveChanges();
                return RedirectToAction("Posts");
            }

            // If the model state is not valid, retrieve the tags again and pass them to the view
            ViewBag.CategoryId = new SelectList(uow.CategoryRepository.GetAll(), "Id", "Name");
            ViewBag.Tags = uow.TagRepository.GetAll().ToList();
            ViewBag.SelectedTags = Tags;

            return View(post);
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var post = uow.PostRepository.Find(id);

                return View(post);
            }
            return RedirectToAction("Posts");

        }
        [HttpPost]
        public IActionResult Delete(int? id, Post post)
        {
            try
            {
                post = uow.PostRepository.Find(id);
                uow.PostRepository.Delete(post);
                uow.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Posts");
        }
    }
}
