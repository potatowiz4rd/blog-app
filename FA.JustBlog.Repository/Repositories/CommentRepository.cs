using FA.JustBlog.Core;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(JustBlogContext dataContext) : base(dataContext)
        {
        }

        public IList<Comment> GetCommentForPost(int postId)
        {
            return dataContext.Comments.Where(c => c.PostId == postId).ToList();
        }

        public IList<Comment> GetCommentForPost(Post post)
        {
            return dataContext.Comments
                .Where(c => c.Post == post)
                .ToList();
        }
    }
}
