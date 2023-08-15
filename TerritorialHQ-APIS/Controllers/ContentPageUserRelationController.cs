using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.DTO;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class ContentPageUserRelationController : BaseDtoController<ContentPageUserRelation, DTOContentPageUserRelation>
    {
        public ContentPageUserRelationController(IBaseService<ContentPageUserRelation> baseService) : base(baseService)
        {
        }
    }
}
