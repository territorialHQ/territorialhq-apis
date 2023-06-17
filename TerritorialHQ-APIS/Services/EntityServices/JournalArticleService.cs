using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Services
{
    public class JournalArticleService : BaseService<JournalArticle>
    {
        public JournalArticleService(ApplicationDbContext context, LoggerService logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {

        }
    }
}
