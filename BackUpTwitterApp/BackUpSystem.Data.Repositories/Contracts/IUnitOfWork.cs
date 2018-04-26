using System;
using System.Threading.Tasks;

namespace BackUpSystem.Data.Repositories.Contracts
{
    /// <summary>
    /// Represent a <see cref="IUnitOfWork"/> interface. Heir of <see cref="IDisposable"/>
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Make a transaction to save the changes of the entities tracked by the context.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are
        /// created for many-to-many relationships and relationships where there is no foreign
        /// key property included in the entity class (often referred to as independent associations).
        /// </returns>
        int SaveChanges();

        /// <summary>
        /// Make a transaction to save the changes asynchronously of the entities tracked by the context.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are
        /// created for many-to-many relationships and relationships where there is no foreign
        /// key property included in the entity class (often referred to as independent associations).
        /// </returns>
        Task<int> SaveChangesAsync();
    }
}
