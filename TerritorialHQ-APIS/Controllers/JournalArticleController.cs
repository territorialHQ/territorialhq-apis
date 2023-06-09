using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerritorialHQ_APIS.Services;
using TerritorialHQ_Library.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TerritorialHQ_APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JournalArticleController : ControllerBase
    {
        private readonly JournalArticleService _journalArticleService;

        public JournalArticleController(JournalArticleService journalArticleService)
        {
            _journalArticleService = journalArticleService;
        }


        // GET: api/<JournalArticleController>
        [HttpGet]
        public async Task<List<JournalArticle>> Get()
        {
            return await _journalArticleService.GetAllAsync();
        }

        // GET api/<JournalArticleController>/5
        [HttpGet("{id}")]
        public async Task<JournalArticle> Get(string id)
        {
            return await _journalArticleService.FindAsync(id); ;
        }

        // POST api/<JournalArticleController>
        [HttpPost]
        public async Task<bool> Post([FromBody] JournalArticle item)
        {
            try
            {
                _journalArticleService.Update(item);
                await _journalArticleService.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        // PUT api/<JournalArticleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JournalArticleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
