using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.IRepositories
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        /// <summary>
        /// Get all Comments from Database by postId
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        IList<Comment> GetCommentForPost(int postId);

        /// <summary>
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        IList<Comment> GetCommentForPost(Post post);
    }
}
