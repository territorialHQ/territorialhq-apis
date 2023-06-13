using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class ClanController : BaseController<Clan>
    {
        public ClanController(IBaseService<Clan> baseService) : base(baseService)
        {
        }
    }
}
