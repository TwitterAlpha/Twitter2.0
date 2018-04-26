using BackUpSystem.Data.Repositories.Contracts;
using Bytes2you.Validation;
using System.Threading.Tasks;

namespace BackUpSystem.Data.Repositories
{
    /// <summary>
    /// Represent a <see cref="UnitOfWork"/> class.
    /// Implementator of <see cref="IUnitOfWork"/>interface.
    /// </summary>

    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>Context that provide connection to the database.</summary>
        private readonly BackUpSystemDbContext dbContext;

        public UnitOfWork(BackUpSystemDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "DbContext").IsNull().Throw();
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Make a transaction to save the changes of the entities tracked by the context.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are
        /// created for many-to-many relationships and relationships where there is no foreign
        /// key property included in the entity class (often referred to as independent associations).
        /// </returns>
        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        /// <summary>
        /// Make a transaction to save the changes asynchronously of the entities tracked by the context.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are
        /// created for many-to-many relationships and relationships where there is no foreign
        /// key property included in the entity class (often referred to as independent associations).
        /// </returns>
        public Task<int> SaveChangesAsync()
        {
            return this.dbContext.SaveChangesAsync();
        }
    }
}
