using Microsoft.EntityFrameworkCore;
using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Services
{
    public class NavigationEntryService : BaseService<NavigationEntry>
    {
        public NavigationEntryService(ApplicationDbContext context, LoggerService logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public override async Task<NavigationEntry?> FindAsync(string id)
        {
            return await Query.FirstOrDefaultAsync(q => q.Id == id || q.Slug == id);
        }
    }
}
