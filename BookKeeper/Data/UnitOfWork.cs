using System;

namespace BookKeeper.Data.Data
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }   

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (_dbContext == null)
                return;

            _dbContext.Dispose();

            _dbContext = null;

        }

    }
}