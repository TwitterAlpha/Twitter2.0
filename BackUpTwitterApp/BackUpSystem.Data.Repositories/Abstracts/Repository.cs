using BackUpSystem.Data;
using BackUpSystem.Date.Repositories.Contracts;
using BlogSystem.Data.Models.Abstracts;
using Bytes2you.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public Repository(BackUpSystemDbContext dbContext)
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
        public async Task<TEntity> Get(string id)
        {
            var result = await this.dbContext.Set<TEntity>().FindAsync(id);

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
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.dbContext.Set<TEntity>().Where(x => !x.IsDeleted).ToListAsync();
        }

        /// <summary>
        /// Provide all the entities including the deleted ones.
        /// </summary>
        /// <returns>All the entities including the deleted ones</returns>
        public async Task<IEnumerable<TEntity>> GetAllAndDeleted()
        {
            return await this.dbContext.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Adds a given entity to the context.
        /// </summary>
        /// <param name="entity">Entity to be added.</param>
        public async void Add(TEntity entity)
        {
            await this.dbContext.Set<TEntity>().AddAsync(entity);
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
    }
}
