using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repository.IRepositories
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        List<Tag> GetPopularTags();
        List<Tag>? GetTagsByPost(int? postId);

    }
}
