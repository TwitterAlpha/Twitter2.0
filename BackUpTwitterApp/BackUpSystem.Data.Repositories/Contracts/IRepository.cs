using BlogSystem.Data.Models.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackUpSystem.Date.Repositories.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : class, IDeletable
    {
        /// <summary>
        /// Find entity by a given id.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>The entity with the provided id if exist. Otherwise <see cref="null"/>.</returns>
        Task<TEntity> Get(string id);

        /// <summary>
        /// Provide all the entities.
        /// </summary>
        /// <returns>All the entities</returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Provide all the entities including all the deleted ones.
        /// </summary>
        /// <returns>All the entities including all the deleted ones</returns>
        Task<IEnumerable<TEntity>> GetAllAndDeleted();

        /// <summary>
        /// Adds a given entity to the context.
        /// </summary>
        /// <param name="entity">Entity to be added.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Deletes a given entity to the context.
        /// </summary>
        /// <param name="entity">Entity to be deleted.</param>
        void Delete(TEntity entity);
    }
}
