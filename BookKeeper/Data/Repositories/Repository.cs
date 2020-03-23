using BookKeeper.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetItem(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetItems();
        IEnumerable<TEntity> GetItems(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] expressions);
        IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperty);
        TEntity Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TEntity> _entities;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }

        public TEntity GetItem(Func<TEntity, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return _entities.FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetItems()
        {
            return _entities.Where(x => x.IsDeleted == false);
        }

        public IEnumerable<TEntity> GetItems(Func<TEntity, bool> predicate)
        {
            return _entities.Where(predicate);
        }

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] expressions)
        {
            return Include(expressions).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperty)
        {
            var query = Include(includeProperty);
            return (query.AsEnumerable() ?? throw new NullReferenceException(nameof(query))).Where(predicate).ToList();
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastSaveDate = DateTime.Now;

            _entities.Add(entity);

            return entity;
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            _entities.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Update(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            _entities.UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Remove(entity);
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _entities.AsNoTracking();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}