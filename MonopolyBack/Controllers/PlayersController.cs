using Microsoft.AspNetCore.Mvc;
using MonopolyBack.Interfaces;
using MonopolyBack.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonopolyBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersService _playersService;

        public PlayersController(IPlayersService playersService)
        {
            _playersService = playersService;
        }

        // GET api/<PlayersController>/5
        [HttpGet("{token}")]
        public List<Players> Get(Guid token)
        {
            return _playersService.GetPlayersStatus(token);
        }

        // POST api/<PlayersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PlayersController>/5
        [HttpPut("{token}")]
        public void Put( Guid token)
        {
            _playersService.ChangePlayer(token);
        }

        // DELETE api/<PlayersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
