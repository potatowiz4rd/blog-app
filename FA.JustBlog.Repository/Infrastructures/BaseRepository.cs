﻿using FA.JustBlog.Core;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Repository.Infrastructures
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
          where TEntity : class
    {
        protected readonly JustBlogContext dataContext;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(JustBlogContext context)
        {
            dataContext = context;
            dbSet = context.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            //_context.Entry<TEntity>(entity);
            dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            // Context.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public TEntity Find(params object[] primaryKey)
        {
            return dbSet.Find(primaryKey);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet;
        }
        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
            // Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
