using FA.JustBlog.Core;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext context) : base(context)
        {
        }

        public List<Tag> GetPopularTags()
        {
            return dataContext.Tags.OrderByDescending(t => t.Count).Take(5).ToList();
        }

        public List<Tag>? GetTagsByPost(int? postId)
        {
            return dataContext.Posts.Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag)
                .FirstOrDefault(p => p.Id == postId)
                ?.PostTagMaps
                .Select(ptm => ptm.Tag)
                .ToList();
        }
    }
}
