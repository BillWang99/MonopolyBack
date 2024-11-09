using Microsoft.AspNetCore.Mvc;
using MonopolyBack.Interfaces;
using MonopolyBack.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonopolyBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundDataController : ControllerBase
    {
        private readonly IPlayersService _playersService;
        private readonly IRoundResultService _roundresultService;
        public RoundDataController(IPlayersService playersService, IRoundResultService roundresultService)
        {
            _playersService = playersService;
            _roundresultService = roundresultService;
        }

        // GET: api/<RoundDataController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RoundDataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoundDataController>
        [HttpPost]
        public void Post([FromBody] RoundData data)
        {
            //紀錄操作金額
            _roundresultService.WriteRoundResult(data);

            //切換玩家
            _playersService.ChangePlayer(data.token);
        }

        // PUT api/<RoundDataController>/5
        [HttpPut("{token}")]
        public void Put(Guid token)
        {
            _playersService.BackToPlayer(token);
        }

        // DELETE api/<RoundDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
