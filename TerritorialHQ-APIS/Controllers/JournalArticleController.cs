using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_APIS.Controllers.Base;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_APIS.Services.Base;
using TerritorialHQ_Library.DTO;
using TerritorialHQ_Library.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TerritorialHQ_APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JournalArticleController : BaseDtoController<JournalArticle, DTOJournalArticle>
    {
        public JournalArticleController(IBaseService<JournalArticle> baseService) : base(baseService)
        {
        }
    }
}
