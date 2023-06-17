using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_Library.Entities;
using Org.BouncyCastle.Asn1.Ocsp;
using System.IdentityModel.Tokens.Jwt;

namespace TerritorialHQ_APIS.Services.Base
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly LoggerService _logger;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseService(ApplicationDbContext context, LoggerService logger, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual IQueryable<TEntity> Query => _context.Set<TEntity>();
        public virtual IQueryable<TEntity> CustomQuery => _context.Set<TEntity>();

        public virtual IList<TEntity> GetAll()
        {
            return Query.ToList();
        }
        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await Query.ToListAsync();
        }

        public virtual EntityEntry<TEntity> Update(TEntity entity)
        {
            return _context.Update(entity);
        }

        public async Task<EntityEntry<TEntity>> Add(TEntity entity)
        {
            entity.Creator = GetIdFromToken();
            entity.Timestamp = DateTime.UtcNow;

            return _context.Set<TEntity>().Add(entity);
        }

        private string? GetIdFromToken()
        {
            string? creator = null;
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext.Request.Headers.ContainsKey("Authorization"))
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(httpContext.Request.Headers["Authorization"].ToString()[7..]);

                creator = token.Claims.FirstOrDefault(c => c.Type == "DiscordId")?.Value;
            }
            return creator;
        }

        public EntityEntry<TEntity> Attach(TEntity entity) => _context.Attach(entity);

        public virtual Task<bool> ExistsAsync(string id) => Query.AnyAsync(e => e.Id == id);
        public virtual bool Exists(string id) => Query.Any(e => e.Id == id);

        public virtual Task<TEntity?> FindAsync(string id) => Query.FirstOrDefaultAsync(e => e.Id == id);

        public Task<int> SaveChangesAsync()
        {
            var entries = _context.ChangeTracker.Entries();
            
            string log = "";
            string? user = GetIdFromToken() ?? "UNKOWN USER";

            log += "USER " + user + ": ";

            foreach (var entry in entries)
            {
                if (entry.State != EntityState.Unchanged)
                {
                    if (entry.State == EntityState.Modified)
                    {
                        log += string.Format("UPDATED ENTITY {0} IN TABLE {1} WITH NEW VALUES ", entry.CurrentValues["Id"]?.ToString(), entry.Metadata.Name);

                        foreach (var v in entry.CurrentValues.Properties)
                        {
                            log += v.Name + " = " + entry.CurrentValues[v]?.ToString() + ", ";
                        }
                    }

                    if (entry.State == EntityState.Added)
                    {
                        log += "ADDED ENTITY TO TABLE " + entry.Metadata.Name + " WITH NEW VALUES ";

                        foreach (var v in entry.CurrentValues.Properties)
                        {
                            log += v.Name + " = " + entry.CurrentValues[v]?.ToString() + ", ";
                        }
                    }

                    if (entry.State == EntityState.Deleted)
                    {
                        log += string.Format("DELETED ENTITY {0} FROM TABLE {1} WITH ORIGINAL VALUES ", entry.CurrentValues["Id"]?.ToString(), entry.Metadata.Name);

                        foreach (var v in entry.OriginalValues.Properties)
                        {
                            log += v.Name + " = " + entry.OriginalValues[v]?.ToString() + ", ";
                        }
                    }

                }
            }

            if (!string.IsNullOrEmpty(log))
                _logger.Log.Information(log);

            return _context.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(string id)
        {
            var entity = await FindAsync(id);
            if (entity != null)
                Remove(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
