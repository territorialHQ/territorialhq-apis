using Microsoft.EntityFrameworkCore;
using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Services
{
    public class ClanUserRelationService : BaseService<ClanUserRelation>
    {
        public ClanUserRelationService(ApplicationDbContext context, LoggerService logger) : base(context, logger)
        {
        }

        public override async Task<ClanUserRelation?> FindAsync(string id)
        {
            var relation = await Query.FirstOrDefaultAsync(u => u.AppUserId == id);
            if (relation != null)
                return relation;

            return await Query.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
