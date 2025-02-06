using System.ComponentModel.DataAnnotations;
using WebAPICodeFirst.DTO.PlayerInstrument;

namespace WebAPICodeFirst.DTO.Player
{
    public class CreatePlayerRequest
    {
        [Required]
        public string NickName { get; set; }
        [Required]
        public List<CreatePlayerInstrumentRequest> PlayerInstrument { get; set; }
    }
}
