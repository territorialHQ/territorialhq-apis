using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.DTO;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class AppUserController : BaseDtoController<AppUser, DTOAppUser>
    {
        public AppUserController(IBaseService<AppUser> baseService) : base(baseService)
        {
        }


        [Authorize(Roles = "Administrator, Staff")]
        public override async Task<List<DTOAppUser>> Get() => await base.Get();

        public override async Task<DTOAppUser?> Get(string? id) => await base.Get(id);

        [Authorize(Roles = "Administrator, Staff")]
        [HttpGet("RoleUsers/{id}")]
        public virtual async Task<List<DTOAppUser>> RoleUsers(AppUserRole id)
        {
            var users = await ((AppUserService)_baseService).GetUsersInRoleAsync(id);
            List<DTOAppUser> result = new List<DTOAppUser>();

            foreach (var user in users) 
                result.Add((DTOAppUser)user.GetDto());

            return result;
        }

        [HttpGet("Public/{id}")]
        public virtual async Task<bool> Public(string id)
        {
            var user = await ((AppUserService)_baseService).FindAsync(id);

            if (user == null)
                return false;

            user.Public = !user.Public;
            _baseService.Update(user);

            await _baseService.SaveChangesAsync();

            return true;
        }
    }
}
