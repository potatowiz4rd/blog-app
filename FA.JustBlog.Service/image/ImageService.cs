using AutoMapper;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Service.category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.image
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public ImageService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
    }
}
