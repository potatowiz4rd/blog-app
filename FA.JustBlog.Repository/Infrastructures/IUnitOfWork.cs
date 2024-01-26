using FA.JustBlog;
using FA.JustBlog.Repository.IRepositories;
using System;

namespace FA.JustBlog.Repository.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository CategoryRepository { get; } // read only
        public IPostRepository PostRepository { get; }
        public ITagRepository TagRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public IImageRepository ImageRepository { get; }


        int SaveChanges();
        Task<int> SaveChangesAsync();

    }
}
