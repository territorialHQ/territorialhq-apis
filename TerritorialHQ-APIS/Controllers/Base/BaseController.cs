using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity> : ControllerBase where TEntity : class, IEntity
    {
        protected readonly IBaseService<TEntity> _baseService;

        public BaseController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public virtual async Task<List<TEntity>> Get()
        {
            return await _baseService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public virtual async Task<IEntity?> Get(string? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _baseService.FindAsync(id);
        }

        [HttpPost]
        public virtual async Task<bool> Post([FromBody] TEntity item)
        {
            try
            {
                _baseService.Add(item);
                await _baseService.SaveChangesAsync();
                return true;
            }
            catch {
                return false;
            }
        }

        [HttpPut()]
        public virtual async Task<bool> Put([FromBody] TEntity item)
        {
            try
            {
                _baseService.Update(item);
                await _baseService.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<bool> Delete(string? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            try
            {
                await _baseService.RemoveAsync(id);
                await _baseService.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
