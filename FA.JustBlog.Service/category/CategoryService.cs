using AutoMapper;
using FA.JustBlog.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.category
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public CategoryService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
    }
}
