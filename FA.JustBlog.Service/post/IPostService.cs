using FA.JustBlog.ViewModel.Posts;
using FA.JustBlog.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.post
{
    public interface IPostService
    {
        ResponseResult<PostViewModel> GetAll();
    }
}
