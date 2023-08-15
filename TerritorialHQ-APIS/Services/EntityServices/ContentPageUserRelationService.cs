using Microsoft.EntityFrameworkCore;
using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Services
{
    public class ContentPageUserRelationService : BaseService<ContentPageUserRelation>
    {
        public ContentPageUserRelationService(ApplicationDbContext context, LoggerService logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public override async Task<ContentPageUserRelation?> FindAsync(string id)
        {
            var relation = await Query.FirstOrDefaultAsync(u => u.AppUserId == id);
            if (relation != null)
                return relation;

            return await Query.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<ContentPageUserRelation>?> GetByPageAsync(string id)
        {
            return await Query.Where(u => u.ContentPageId == id).ToListAsync();
        }
    }
}
