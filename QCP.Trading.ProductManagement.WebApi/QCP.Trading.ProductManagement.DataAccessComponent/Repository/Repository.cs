using Microsoft.EntityFrameworkCore;
using QCP.Trading.ProductManagement.DataAccessComponent.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QCP.Trading.ProductManagement.DataAccessComponent.Repository
{
    /// <summary>
    /// Generic base repository class. This will have all common methods that are normally 
    /// done on any repository
    /// </summary>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Adds an entity into the repository
        /// </summary>
        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Adds a range of entities into the repository
        /// </summary>
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        /// <summary>
        ///  Attaches an existing entity marked as modified
        /// </summary>
        public virtual void Edit(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Performs a search on the repository for the given predicate
        /// and returns a list of matched entities
        /// </summary>
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().AsNoTracking().Where(predicate);
        }

        /// <summary>
        /// Performs a search on the repository for the given predicate
        /// and returns a list of matched entities
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// Gets all entities in a repository as a list
        /// </summary>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Removes one given entity from repository
        /// </summary>
        public virtual void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Removes a range of given entities from the repository
        /// </summary>
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

    }
}
