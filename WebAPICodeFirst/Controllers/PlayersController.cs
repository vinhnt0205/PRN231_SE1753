using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICodeFirst.DTO;
using WebAPICodeFirst.DTO.Player;
using WebAPICodeFirst.Services.PlayerServices;

namespace WebAPICodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost]
        public async Task<IActionResult> PostPlayerAsync([FromBody] CreatePlayerRequest playerRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _playerService.CreatePlayerAsync(playerRequest);
            return Ok(playerRequest);
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeletePlayerAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var result = await _playerService.DeletePlayerAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}/detail")]
        public async Task<IActionResult> GetPlayerDetailAsync(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            var player = await _playerService.GetPlayerDetailAsync(id);
            return Ok(player);
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayersAsync([FromQuery] UrlQueryParamters urlQueryParamters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var players = await _playerService.GetPlayersAsync(urlQueryParamters);
            return Ok(players);
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> PutPlayerAsync(int id, [FromBody] UpdatePlayerRequest playerRequest)
        {
            if(id <= 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _playerService.UpdatePlayerAsync(id, playerRequest);
            return NoContent();
        }
    }
}
