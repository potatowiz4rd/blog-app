using FA.JustBlog.ViewModel.Categories;
using FA.JustBlog.ViewModel.Comments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FA.JustBlog.ViewModel.Posts
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string PostContent { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public bool Modified { get; set; }
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        [NotMapped]
        public decimal Rate { get => RateCount == 0 ? 0m : TotalRate * 1.0m / RateCount; }
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        //public ICollection<PostTagMap> PostTagMaps { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }

    }
}
