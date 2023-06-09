using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace TerritorialHQ_APIS.Services
{
    public class AppUserService : BaseService<AppUser>
    {
        public AppUserService(ApplicationDbContext context, LoggerService logger) : base(context, logger)
        {

        }

        public async Task<AppUser?> GetByUsernameAsync(string userName)
        {
            return await Query.FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
