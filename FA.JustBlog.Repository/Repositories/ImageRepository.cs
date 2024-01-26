using FA.JustBlog.Core.Models;
using FA.JustBlog.Core;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Repository.Repositories
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(JustBlogContext context) : base(context)
        {
        }

        public IList<Image> GetImagesForPost(Post post)
        {
            return dataContext.Images.Where(i => i.PostId == post.Id).ToList();
        }
    }
}
