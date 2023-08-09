using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace TerritorialHQ_APIS.Services
{
    public class AppUserRoleRelationService : BaseService<AppUserRoleRelation>
    {
        public AppUserRoleRelationService(ApplicationDbContext context, LoggerService logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {

        }
    }
}
