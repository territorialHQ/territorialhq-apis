using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Services
{
    public class ClanService : BaseService<Clan>
    {
        public ClanService(ApplicationDbContext context, LoggerService logger) : base(context, logger)
        {
        }
    }
}
