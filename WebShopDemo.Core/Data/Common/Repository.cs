using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace WebShopDemo.Core.Data.Common
{
    /// <summary>
    /// Implementation of repository access methods
    /// for relational database engine
    /// </summary>
    public class Repository : IRepository
    {
        /// <summary>
        /// Entity framework DB context holding connection information and properties
        /// and tracking entity states
        /// </summary>
        protected DbContext Context { get; set; }

        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="context">Application database context</param>
        public Repository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Representation of table in database
        /// </summary>
        protected DbSet<T> DbSet<T>() where T : class
        {
            return this.Context.Set<T>();
        }

        /// <inheritdoc />
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        /// <inheritdoc />
        public IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class
        {
            return DbSet<T>().Where(search);
        }

        /// <inheritdoc />
        public IQueryable<T> AllReadonly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        /// <inheritdoc />
        public IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : class
        {
            return DbSet<T>().Where(search).AsNoTracking();
        }

        /// <inheritdoc />
        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        /// <inheritdoc />
        public async Task<T?> GetByIdsAsync<T>(object[] id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        /// <inheritdoc />
        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        /// <inheritdoc />
        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await DbSet<T>().AddRangeAsync(entities);
        }

        /// <inheritdoc />
        public void Update<T>(T entity) where T : class
        {
            DbSet<T>().Update(entity);
        }

        /// <inheritdoc />
        public void UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            DbSet<T>().UpdateRange(entities);
        }

        /// <inheritdoc />
        public async Task DeleteAsync<T>(object id) where T : class
        {
            T? entity = await GetByIdAsync<T>(id);

            if (entity != null)
            {
                Delete(entity);
            }
        }

        /// <inheritdoc />
        public void Delete<T>(T entity) where T : class
        {
            EntityEntry entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                DbSet<T>().Attach(entity);
            }

            entry.State = EntityState.Deleted;
        }

        /// <inheritdoc />
        public void DeleteRange<T>(IEnumerable<T> entities) where T : class
        {
            DbSet<T>().RemoveRange(entities);
        }

        /// <inheritdoc />
        public void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : class
        {
            var entities = All<T>(deleteWhereClause);
            DeleteRange(entities);
        }

        /// <inheritdoc />
        public void Detach<T>(T entity) where T : class
        {
            EntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        /// <inheritdoc />
        public async Task<int> SaveChangesAsync()
        {
            return await this.Context.SaveChangesAsync();
        }

        /// <summary>
        /// Disposing the context when repository is disposed
        /// </summary>
        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
