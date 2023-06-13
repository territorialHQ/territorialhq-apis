using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class NavigationEntryController : BaseController<NavigationEntry>
    {
        public NavigationEntryController(IBaseService<NavigationEntry> baseService) : base(baseService)
        {
        }
    }
}
