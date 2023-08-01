using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.DTO;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class ClanUserRelationController : BaseDtoController<ClanUserRelation, DTOClanUserRelation>
    {
        public ClanUserRelationController(IBaseService<ClanUserRelation> baseService) : base(baseService)
        {
        }
    }
}
