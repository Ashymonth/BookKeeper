using BookKeeper.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookKeeper.Data.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetItem(Func<TEntity, bool> predicate);
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

        public int Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.LastSaveDate = DateTime.Now;

            _entities.Add(entity);

            return entity.Id;
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Remove(entity);
        }

        public TEntity GetItem(Func<TEntity, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return _entities.FirstOrDefault(predicate);
        }
    }
}
