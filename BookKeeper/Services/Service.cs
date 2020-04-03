using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookKeeper.Data.Services
{
    public interface IService<TModel> where TModel : BaseEntity
    {
        TModel Add(TModel entity);

        void Add(IList<TModel> entities);
        
        int Update(TModel entity);
        
        void Update(IEnumerable<TModel> entities);
        
        void Delete(TModel entity);
        
        TModel GetItem(Func<TModel, bool> predicate);

        TModel GetItemById(int id);
        
        IEnumerable<TModel> GetItems();
        
        IEnumerable<TModel> GetItems(Func<TModel, bool> predicate);
        
        IEnumerable<TModel> GetWithInclude(params Expression<Func<TModel, object>>[] expressions);
        
        IEnumerable<TModel> GetWithInclude(Func<TModel, bool> predicate, params Expression<Func<TModel, object>>[] includeProperty);

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

        public TModel Add(TModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var result = _repository.Add(entity);
            _unitOfWork.Commit();
            return result;
        }

        public void Add(IList<TModel> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            _repository.Add(entities);
            _unitOfWork.Commit();
        }

        public int Update(TModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.Update(entity);
            return _unitOfWork.Commit();
        }

        public void Update(IEnumerable<TModel> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            _repository.Update(entities);
            _unitOfWork.Commit();
        }


        public void Delete(TModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public TModel GetItem(Func<TModel, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return _repository.GetItem(predicate);
        }

        public TModel GetItemById(int id)
        {
            return _repository.GetItemById(id);
        }

        public IEnumerable<TModel> GetItems()
        {
            return _repository.GetItems();
        }

        public IEnumerable<TModel> GetItems(Func<TModel, bool> predicate)
        {
            return _repository.GetItems(predicate);
        }

        public IEnumerable<TModel> GetWithInclude(params Expression<Func<TModel, object>>[] expressions)
        {
            return _repository.GetWithInclude(expressions);
        }

        public IEnumerable<TModel> GetWithInclude(Func<TModel, bool> predicate, params Expression<Func<TModel, object>>[] includeProperty)
        {
            return _repository.GetWithInclude(predicate, includeProperty);
        }
    }
}