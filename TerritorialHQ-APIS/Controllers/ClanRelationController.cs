using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.DTO;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class ClanRelationController : BaseDtoController<ClanRelation, DTOClanRelation>
    {
        public ClanRelationController(IBaseService<ClanRelation> baseService) : base(baseService)
        {
        }

        [HttpGet("Clan/{id}")]
        public async Task<List<DTOClanRelation>> GetByClan(string id)
        {
            var relations = await ((ClanRelationService)_baseService).GetByClanAsync(id);

            List<DTOClanRelation> response = new();
            foreach (var relation in relations)
            {
                response.Add((DTOClanRelation)relation.GetDto());
            }

            return response;
        }


        public override async Task<bool> Delete(string? id)
        {
            return await base.Delete(id);
        }
    }
}
