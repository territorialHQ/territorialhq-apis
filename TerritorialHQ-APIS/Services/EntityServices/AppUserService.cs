using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace TerritorialHQ_APIS.Services
{
    public class AppUserService : BaseService<AppUser>
    {
        public AppUserService(ApplicationDbContext context, LoggerService logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {

        }

        public override async Task<AppUser?> FindAsync(string id)
        {
            var user = await Query.FirstOrDefaultAsync(u => u.UserName == id);
            if (user != null)
                return user;

            return await Query.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<AppUser>> GetUsersInRoleAsync(AppUserRole role)
        {
            return await Query.Where(u => u.Role == role).ToListAsync();
        }
    }
}
