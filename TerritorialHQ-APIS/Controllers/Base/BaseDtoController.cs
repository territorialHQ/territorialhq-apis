using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.DTO.Interface;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseDtoController<TEntity, TDto> : ControllerBase where TEntity : class, IEntity, new() where TDto : class, IDto
    {
        protected readonly IBaseService<TEntity> _baseService;

        public BaseDtoController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public virtual async Task<List<TDto>> Get()
        {
            var entities = await _baseService.GetAllAsync();
            var items = new List<TDto>();

            foreach (var entity in entities)
                items.Add((TDto)entity.GetDto());

            return items;
        }

        [HttpGet("{id}")]
        public virtual async Task<TDto?> Get(string? id) 
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var item = await _baseService.FindAsync(id);
            var dto =  item?.GetDto();

            return (TDto?)dto;
        }

        [HttpPost]
        [Authorize]
        public virtual async Task<bool> Post([FromBody] TDto item)
        {
            try
            {
                var entity = new TEntity();
                entity.MapDto(item);

                await _baseService.Add(entity);
                await _baseService.SaveChangesAsync();
                return true;
            }
            catch {
                return false;
            }
        }

        [HttpPut()]
        [Authorize]
        public virtual async Task<bool> Put([FromBody] TDto item)
        {
            try
            {
                var entity = await _baseService.FindAsync(item.Id!);
                if (entity != null)
                {
                    entity.MapDto(item);

                    _baseService.Update(entity);
                    await _baseService.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
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
