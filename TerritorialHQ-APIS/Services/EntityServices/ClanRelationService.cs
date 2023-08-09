using Microsoft.EntityFrameworkCore;
using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Services
{
    public class ClanRelationService : BaseService<ClanRelation>
    {
        public ClanRelationService(ApplicationDbContext context, LoggerService logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public async Task<List<ClanRelation>?> GetByClanAsync(string id)
        {
            return await Query.Where(u => u.ClanId == id).ToListAsync();
        }
    }
}
