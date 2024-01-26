using FA.JustBlog.ViewModel.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModel.Images
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int PostId { get; set; }
        public string Description { get; set; }
        public PostViewModel Post { get; set; }
    }
}
