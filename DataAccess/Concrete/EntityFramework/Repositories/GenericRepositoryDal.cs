using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class GenericRepositoryDal<TEntity, TContext> : IGenericRepositoryDal<TEntity> where TEntity : class where TContext : DbContext, new()
    {
        public virtual TEntity Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public virtual TEntity Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
                return entity;
            }
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            using (var context = new TContext())
            {
                return predicate == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(predicate).ToList();
            }
        }

        public virtual TEntity GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public virtual TEntity GetOne(Expression<Func<TEntity, bool>> predicate = null)
        {
            using (var context = new TContext())
            {
                return predicate == null
                    ? context.Set<TEntity>().SingleOrDefault()
                    : context.Set<TEntity>().Where(predicate).SingleOrDefault();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                if (predicate != null)
                {
                    query = query.Where(predicate);
                }
                if (includeProperties.Any())
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }
                return query.FirstOrDefault();
            }
        }
        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                if (predicate != null)
                {
                    query = query.Where(predicate);
                }
                if (includeProperties.Any())
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }
                return query.ToList();
            }
        }
        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            using (TContext context = new TContext())
            {
                return (predicate == null ? context.Set<TEntity>().Count() : context.Set<TEntity>().Count(predicate));
            }
        }
        public virtual TEntity Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }
    }
}
