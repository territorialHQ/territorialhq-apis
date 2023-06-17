using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TerritorialHQ_APIS.Services
{
    public class ContentPageService : BaseService<ContentPage>
    {
        public ContentPageService(ApplicationDbContext context, LoggerService logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {

        }
    }

}
