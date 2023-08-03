using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.DTO;
using TerritorialHQ_Library.DTO.Interface;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    public class ContentCreatorController : BaseDtoController<ContentCreator, DTOContentCreator>
    {
        public ContentCreatorController(IBaseService<ContentCreator> baseService) : base(baseService)
        {
        }
    }
}
