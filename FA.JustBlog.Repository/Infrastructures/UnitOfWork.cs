
using FA.JustBlog.Core;
using FA.JustBlog.Repository.IRepositories;
using FA.JustBlog.Repository.Repositories;

namespace FA.JustBlog.Repository.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext _context;
        private ICategoryRepository _categoryRepository;
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;
        private ICommentRepository _commentRepository;
        private IImageRepository _imageRepository;

        public UnitOfWork(JustBlogContext context = null)
        {
            _context = context ?? new JustBlogContext();
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            }
        }

        public IPostRepository PostRepository => _postRepository ?? new PostRepository(_context);
        public IImageRepository ImageRepository => _imageRepository ?? new ImageRepository(_context);

        public ITagRepository TagRepository
        {
            get
            {
                if (_tagRepository == null)
                {
                    _tagRepository = new TagRepository(_context);
                }
                return _tagRepository;
            }
        }

        public ICommentRepository CommentRepository => _commentRepository ?? new CommentRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            this._context?.Dispose();
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
