using Microsoft.AspNetCore.Mvc;
using MonopolyBack.Interfaces;
using MonopolyBack.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonopolyBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameHistoryController : ControllerBase
    {
        private readonly IGameHistoryService _gameHistoryService;
        public GameHistoryController(IGameHistoryService gameHistoryService)
        {
            _gameHistoryService = gameHistoryService;
        }

        // GET: api/<GameHistoryController>
        [HttpGet]
        public IEnumerable<GameHistory> Get()
        {
            return _gameHistoryService.GetAllGames();
        }

        // GET api/<GameHistoryController>/5
        [HttpGet("{id}")]
        public Guid Get(int id)
        {
            return _gameHistoryService.GetToken(id);
        }

        // POST api/<GameHistoryController>
        [HttpPost]
        public Guid Post([FromBody] int count)
        {
            return _gameHistoryService.NewGame(count);
        }

        // PUT api/<GameHistoryController>/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
            _gameHistoryService.SetGameToDelete(id);
        }

        // DELETE api/<GameHistoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
