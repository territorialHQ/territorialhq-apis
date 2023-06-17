using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.DTO;
using TerritorialHQ_Library.DTO.Interface;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class ContentPageController : BaseDtoController<ContentPage, DTOContentPage>
    {
        public ContentPageController(IBaseService<ContentPage> baseService) : base(baseService)
        {
        }

    }
}
