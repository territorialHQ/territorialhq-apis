using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Services.Base
{
    public interface IBaseService<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> CustomQuery { get; }
        IQueryable<TEntity> Query { get; }

        Task<EntityEntry<TEntity>> Add(TEntity entity);
        EntityEntry<TEntity> Attach(TEntity entity);
        bool Exists(string id);
        Task<bool> ExistsAsync(string id);
        Task<TEntity?> FindAsync(string id);
        IList<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        void Remove(TEntity entity);
        Task RemoveAsync(string id);
        Task<int> SaveChangesAsync();
        EntityEntry<TEntity> Update(TEntity entity);
    }
}