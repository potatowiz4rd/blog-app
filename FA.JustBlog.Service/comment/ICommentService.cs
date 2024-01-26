using FA.JustBlog.ViewModel.Comments;
using FA.JustBlog.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.comment
{
    public interface ICommentService
    {
        ResponseResult<CommentViewModel> GetAll();
    }
}
