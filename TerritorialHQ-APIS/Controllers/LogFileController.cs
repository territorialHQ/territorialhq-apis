using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_Library.Entities;

namespace TerritorialHQ_APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LogFileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public virtual async Task<List<string>> Get()
        {
            var dir = _webHostEnvironment.WebRootPath + "/Data/Logs";
            if (!System.IO.Directory.Exists(dir))
                return new();

            List<string> result = new();
            var files = System.IO.Directory.GetFiles(dir);
            foreach (var file in files)
            {
                result.Add(System.IO.Path.GetFileName(file));
            }

            return result.OrderByDescending(o => o).ToList();
        }

    }
}
