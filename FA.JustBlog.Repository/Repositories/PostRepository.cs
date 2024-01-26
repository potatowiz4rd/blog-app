using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Repository.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext dataContext) : base(dataContext)
        {
        }

        public int CountPostsForCategory(string category)
        {
            var result = dataContext.Posts.Join(dataContext.Categories, x => x.CategoryId, y => y.Id, (x, y) => new
            {
                y.Name
            }).Count(x => x.Name.Contains(category, StringComparison.OrdinalIgnoreCase));//.Count();


            return result;
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            return dataContext.Posts.FirstOrDefault(x => x.PostedOn.Year == year && x.PostedOn.Month == month && x.UrlSlug.ToLower().Contains(urlSlug.ToLower().Trim()));
        }


        public IList<Post> GetPostsByCategory(string category)
        {
            return dataContext.Posts.Join(dataContext.Categories, x => x.CategoryId, y => y.Id, (x, y) => new
            {
                Post = x,
                Category = y
            }).Where(y => y.Category.Name == category).Select(x => x.Post).ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            return dataContext.Posts
                    .Where(p => p.PostTagMaps.Any(ptm => ptm.Tag.Name == tag))
                    .ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return dataContext.Posts.Where(x => x.PostedOn.Month == monthYear.Month).ToList();
        }


        public IList<Post> GetPublisedPosts()
        {
            return dataContext.Posts.Where(x => x.Published).ToList();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return dataContext.Posts.Where(x => !x.Published).ToList();
        }

        public Post GetPostByCondition(int year, int month, string title)
        {
            return dataContext.Posts
                    .Include(p => p.PostTagMaps)
                    .ThenInclude(ptm => ptm.Tag)
                    .FirstOrDefault(x => x.PostedOn.Year == year && x.PostedOn.Month == month && x.Title.ToLower().Contains(title.ToLower()) == true);
        }

        public List<Post> LatestPosts()
        {
            return dataContext.Posts.OrderByDescending(x => x.PostedOn).Take(3).ToList();

        }
    }
}
