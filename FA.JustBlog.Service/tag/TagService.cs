using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.ViewModel.Posts;
using FA.JustBlog.ViewModel.Responses;
using FA.JustBlog.ViewModel.Tags;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.tag
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public TagService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public ResponseResult<TagViewModel> GetAll()
        {
            ResponseResult<TagViewModel> response = new ResponseResult<TagViewModel>();

            try
            {
                var tags = uow.TagRepository.GetAll();
                if (tags == null || tags.Count() == 0)
                {
                    return new ResponseResult<TagViewModel>() { Message = "No data", StatusCode = 404 };
                }
                var tagModels = mapper.Map<List<TagViewModel>>(tags);
                return new ResponseResult<TagViewModel>() { DataList = tagModels, Message = "Success" };
            }
            catch (Exception ex)
            {
                response.Message = "Error 500 Server";
            }

            return response;
        }

        public void UpdateTagCounts()
        {
            var tags = uow.TagRepository.GetAll();

            foreach (var tag in tags)
            {
                var postsWithTag = uow.PostRepository.GetPostsByTag(tag.Name);
                tag.Count = postsWithTag.Count;
            }

            uow.SaveChanges();
        }

    }
}
