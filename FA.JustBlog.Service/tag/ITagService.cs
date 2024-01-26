using FA.JustBlog.ViewModel.Responses;
using FA.JustBlog.ViewModel.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.tag
{
    public interface ITagService
    {
        ResponseResult<TagViewModel> GetAll();

    }
}
