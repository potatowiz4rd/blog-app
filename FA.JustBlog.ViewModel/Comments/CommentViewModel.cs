using FA.JustBlog.ViewModel.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModel.Comments
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CommentHeader { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }
        public int PostId { get; set; }
        public PostViewModel Post { get; set; }
    }
}
