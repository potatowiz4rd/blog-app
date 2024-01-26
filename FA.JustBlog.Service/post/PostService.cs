using AutoMapper;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.ViewModel.Posts;
using FA.JustBlog.ViewModel.Responses;

namespace FA.JustBlog.Service.post
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public PostService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public ResponseResult<PostViewModel> GetAll()
        {
            ResponseResult<PostViewModel> response = new ResponseResult<PostViewModel>();

            try
            {
                var posts = uow.PostRepository.GetAll();
                if (posts == null || posts.Count() == 0)
                {
                    return new ResponseResult<PostViewModel>() { Message = "No data", StatusCode = 404 };
                }
                var postModels = mapper.Map<List<PostViewModel>>(posts);
                return new ResponseResult<PostViewModel>() { DataList = postModels, Message = "Success" };
            }
            catch (Exception ex)
            {
                response.Message = "Error 500 Server";
            }

            return response;
        }
    }
}
