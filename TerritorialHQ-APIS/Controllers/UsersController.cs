using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppUserService _userService;

        public UsersController(AppUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<AppUser>> Get()
        {
            return await _userService.GetAllAsync();
        }

    }
}
