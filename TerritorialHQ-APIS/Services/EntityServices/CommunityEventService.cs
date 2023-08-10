using Microsoft.EntityFrameworkCore;
using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Services
{
    public class CommunityEventService : BaseService<CommunityEvent>
    {
        public CommunityEventService(ApplicationDbContext context, LoggerService logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public async Task<List<CommunityEvent>?> GetBetween(DateTime from, DateTime to, bool includeRecurring = false)
        {
            var query = Query.Where(e => e.IsPublished && e.Start <= to && e.End >= from);
            if (!includeRecurring)
                query = query.Where(e => !e.Recurring);

            return await query.ToListAsync();
        }

        public async Task<List<CommunityEvent>?> GetRecurring()
        {
            return await Query.Where(e => e.IsPublished && e.Recurring).ToListAsync();
        }
    }
}
