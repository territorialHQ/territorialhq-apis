using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MySql.Data.MySqlClient;
using TerritorialHQ_Library.Entities;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace TerritorialHQ_APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class LogFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _config;

        public LogFileController(IWebHostEnvironment webHostEnvironment, IConfiguration config)
        {
            _webHostEnvironment = webHostEnvironment;
            _config = config;
        }

        [HttpGet("{fileName}")]
        public virtual async Task<FileContentResult?> Get(string fileName)
        {
            var path = _webHostEnvironment.WebRootPath + "/Data/Logs/" + fileName;
            if (!System.IO.File.Exists(path))
                return null;

            try
            {
                var content = await System.IO.File.ReadAllBytesAsync(path);
                new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string contentType);

                return File(content, contentType, fileName);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet("List")]
        public virtual async Task<List<string>> GetAllAsync()
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

        [HttpGet("SqlBackup")]
        public virtual async Task<FileContentResult?> GetSqlBackup()
        {
            var db_server = ConfigurationBinder.GetValue<string>(_config, "DB_SERVER");
            var db_port = ConfigurationBinder.GetValue<string>(_config, "DB_PORT") ?? "3306";
            var db_cat = ConfigurationBinder.GetValue<string>(_config, "DB_CATALOGUE");
            var db_user = ConfigurationBinder.GetValue<string>(_config, "DB_USER");
            var db_pw = ConfigurationBinder.GetValue<string>(_config, "DB_PASSWORD");

            var connectionString = $"Server={db_server};Port={db_port};Database={db_cat};Uid={db_user};Pwd={db_pw};";

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            var fileName = "territorialhq-db-" + DateTime.Now.Ticks.ToString() + ".sql";
            var tempFilePath = System.IO.Path.GetTempPath() + fileName;

            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                using var mb = new MySqlBackup(cmd);
                mb.ExportToFile(tempFilePath);
            }

            var fileBytes = System.IO.File.ReadAllBytes(tempFilePath);
            System.IO.File.Delete(tempFilePath);

            return File(fileBytes, "application/octet-stream", fileName);
        }

    }
}
