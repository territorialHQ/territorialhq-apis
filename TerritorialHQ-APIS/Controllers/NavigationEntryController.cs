using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.DTO;
using TerritorialHQ_Library.DTO.Interface;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class NavigationEntryController : BaseDtoController<NavigationEntry, DTONavigationEntry>
    {
        public NavigationEntryController(IBaseService<NavigationEntry> baseService) : base(baseService)
        {
        }

        public override async Task<List<DTONavigationEntry>> Get()
        {
            var entities = await _baseService.GetAllAsync();
            var items = new List<DTONavigationEntry>();

            foreach (var entity in entities.Where(e => e.ParentId == null))
                items.Add((DTONavigationEntry)entity.GetDto());

            return items;
        }
    }
}
