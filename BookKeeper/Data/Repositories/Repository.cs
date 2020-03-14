using BookKeeper.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(Func<TEntity, bool> predicate);
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

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastSaveDate = DateTime.Now;

            _entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Remove(entity);
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return _entities.FirstOrDefault(predicate);
        }
    }
}
