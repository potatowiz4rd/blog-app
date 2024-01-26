using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModel.Categories;
using FA.JustBlog.ViewModel.Comments;
using FA.JustBlog.ViewModel.Posts;
using FA.JustBlog.ViewModel.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.mapper_config
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<Tag, TagViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
        }
    }
}
