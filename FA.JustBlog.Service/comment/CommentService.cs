using AutoMapper;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.ViewModel.Comments;
using FA.JustBlog.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.comment
{
    public class CommentService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public CommentService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public ResponseResult<CommentViewModel> GetAll()
        {
            ResponseResult<CommentViewModel> response = new ResponseResult<CommentViewModel>();

            try
            {
                var comments = uow.CommentRepository.GetAll();
                if (comments == null || comments.Count() == 0)
                {
                    return new ResponseResult<CommentViewModel>() { Message = "No data", StatusCode = 404 };
                }
                var commentModels = mapper.Map<List<CommentViewModel>>(comments);
                return new ResponseResult<CommentViewModel>() { DataList = commentModels, Message = "Success" };
            }
            catch (Exception ex)
            {
                response.Message = "Error 500 Server";
            }

            return response;
        }
    }
}
