using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Repositories;
using System;

namespace BookKeeper.Data.Services
{
    public interface IService<TModel> where TModel : BaseEntity
    {
        int Add(TModel entity);
        void Delete(TModel entity);
        TModel GetItem(Func<TModel, bool> predicate);
        int Save();
    }

    public class Service<TModel> : IService<TModel> where TModel : BaseEntity
    {
        private readonly IRepository<TModel> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IRepository<TModel> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public int Add(TModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return _repository.Add(entity);
        }

        public void Delete(TModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.Delete(entity);
        }

        public TModel GetItem(Func<TModel, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return _repository.GetItem(predicate);
        }

        public int Save()
        {
            using (_unitOfWork)
            {
                return _unitOfWork.Commit();
            }
        }
    }
}
