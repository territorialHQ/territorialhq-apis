using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class ContentPageController : BaseController<ContentPage>
    {
        public ContentPageController(IBaseService<ContentPage> baseService) : base(baseService)
        {
        }
    }
}
