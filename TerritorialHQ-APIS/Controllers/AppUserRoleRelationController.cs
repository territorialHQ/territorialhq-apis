using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.DTO;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class AppUserRoleRelationController : BaseDtoController<AppUserRoleRelation, DTOAppUserRoleRelation>
    {
        public AppUserRoleRelationController(IBaseService<AppUserRoleRelation> baseService) : base(baseService)
        {
        }
    }
}
