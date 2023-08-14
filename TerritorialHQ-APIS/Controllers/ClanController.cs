using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.DTO;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class ClanController : BaseDtoController<Clan, DTOClan>
    {
        public ClanController(IBaseService<Clan> baseService) : base(baseService)
        {
        }

        [Authorize(Roles = "Administrator, Staff")]
        public override async Task<string?> Post([FromBody] DTOClan item) => await base.Post(item);


        [HttpGet("Listing")]
        public async Task<List<DTOClanListEntry>> Listing()
        {
            var clans = await ((ClanService)_baseService).GetAllAsync();

            List<DTOClanListEntry> response = new();
            foreach (var clan in clans)
            {
                response.Add(clan.GetDtoListEntry());
            }

            return response;
        }

    }
}
