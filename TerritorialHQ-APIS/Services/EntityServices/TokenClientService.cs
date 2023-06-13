using Microsoft.EntityFrameworkCore;
using TerritorialHQ_APIS.Models.Data;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Services
{
    public class TokenClientService : BaseService<TokenClient>
    {
        public TokenClientService(ApplicationDbContext context, LoggerService logger) : base(context, logger)
        {

        }

        public async Task<TokenClient?> GetByNameAsync(string name)
        {
            return await Query.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
