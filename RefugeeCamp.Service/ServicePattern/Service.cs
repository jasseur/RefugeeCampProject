﻿

using RefugeeCamp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace RefugeeCamp.Service.ServicePattern
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        #region Private Fields
        // private readonly IRepositoryBaseAsync<TEntity> _repository;
        IUnitOfWork utwk;
        #endregion Private Fields

        #region Constructor
        protected Service(IUnitOfWork utwk)
        {                                                               
            this.utwk = utwk;
        }
        #endregion Constructor



        public virtual void Add(TEntity entity)
        {
            ////_repository.Add(entity);
            utwk.GetRepository<TEntity>().Add(entity);
            
        }

        public virtual void Update(TEntity entity)
        {
            //_repository.Update(entity);
            utwk.GetRepository<TEntity>().Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            //   _repository.Delete(entity);
            utwk.GetRepository<TEntity>().Delete(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            // _repository.Delete(where);
            utwk.GetRepository<TEntity>().Delete(where);
        }

        public virtual TEntity GetById(long id)
        {
            //  return _repository.GetById(id);
           return utwk.GetRepository<TEntity>().GetById(id);
        }

        public virtual TEntity GetById(string id)
        {
            //return _repository.GetById(id);
            return utwk.GetRepository<TEntity>().GetById(id);
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter = null)
        {
            //  return _repository.GetAll();
            return utwk.GetRepository<TEntity>().GetMany(filter);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            //return _repository.Get(where);
            return utwk.GetRepository<TEntity>().Get(where);
        }

        //public virtual async Task<int> CountAsync()
        //{
        //    //return await _repository.CountAsync();
        //    return await utwk.GetRepository<TEntity>().CountAsync();
        //}

        //public virtual async Task<List<TEntity>> GetAllAsync()
        //{
        //    //return await _repository.GetAllAsync();
        //    return await utwk.GetRepository<TEntity>().GetAllAsync();
        //}

        //public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        //{
        //    //return await _repository.FindAsync(match);
        //    return await utwk.GetRepository<TEntity>().FindAsync(match);
        //}

        //public virtual async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        //{
        //    // return await _repository.FindAllAsync(match);
        //    return await utwk.GetRepository<TEntity>().FindAllAsync(match);
        //}

        public virtual IEnumerable<TEntity> GetAll()
        {
            //  return _repository.GetAll();
            return utwk.GetRepository<TEntity>().GetAll();
        }


        public void Commit()
        {
            try
            {
                utwk.Commit();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //public void CommitAsync()
        //{
        //    try
        //    {
        //        utwk.CommitAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        public void Dispose()
        {
            utwk.Dispose();
        }
    }
}
