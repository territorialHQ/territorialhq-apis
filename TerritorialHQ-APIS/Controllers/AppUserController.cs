using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class AppUserController : BaseController<AppUser>
    {
        public AppUserController(IBaseService<AppUser> baseService) : base(baseService)
        {
        }


        [HttpGet("RoleUsers/{id}")]
        public virtual async Task<List<AppUser>> Get(AppUserRole id)
        {
            return await ((AppUserService)_baseService).GetUsersInRoleAsync(id);
        }

    }
}
