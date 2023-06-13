﻿using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class ClanUserRelationController : BaseController<ClanUserRelation>
    {
        public ClanUserRelationController(IBaseService<ClanUserRelation> baseService) : base(baseService)
        {
        }
    }
}