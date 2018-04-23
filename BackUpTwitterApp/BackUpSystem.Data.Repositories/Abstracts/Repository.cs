using BackUpSystem.Data;
using BackUpSystem.Date.Repositories.Contracts;
using BlogSystem.Data.Models.Abstracts;
using Bytes2you.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackUpSystem.Date.Repositories.Abstractions
{
    /// <summary>
    /// Represent a <see cref="Repository"/> class implementator of <see cref="IRepository"/> interface.
    /// </summary>
    /// <typeparam name="TEntity">Type of entities provided by the instance of the <see cref="Repository"/> class heir.</typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletable
    {
        /// <summary>
        /// Context providing connection to the database.
        /// </summary>
        private readonly BackUpSystemDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class heir.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        protected Repository(BackUpSystemDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "DbContext").IsNull().Throw();
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the Context of the <see cref="Repository"/> class.
        /// </summary>
        public BackUpSystemDbContext DbContext => this.dbContext;

        /// <summary>
        /// Find entity by a given id.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>The entity with the provided id if exist. Otherwise <see cref="null"/>.</returns>
        public TEntity Get(string id)
        {
            var result = this.dbContext.Set<TEntity>().Find(id);

            if (result.IsDeleted)
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Provide all the entities.
        /// </summary>
        /// <returns>All the entities</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return this.dbContext.Set<TEntity>().Where(x => !x.IsDeleted).ToList();
        }

        /// <summary>
        /// Provide all the entities including the deleted ones.
        /// </summary>
        /// <returns>All the entities including the deleted ones</returns>
        public IEnumerable<TEntity> GetAllAndDeleted()
        {
            return this.dbContext.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Adds a given entity to the context.
        /// </summary>
        /// <param name="entity">Entity to be added.</param>
        public void Add(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Soft delete on a given entity.
        /// </summary>
        /// <param name="entity">Entity to be flagged as deleted.</param>
        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// Marks a given entity as updated.
        /// </summary>
        /// <param name="entity">Entity to be modified.</param>
        public void Update(TEntity entity)
        {
            EntityEntry entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbContext.Set<TEntity>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}
