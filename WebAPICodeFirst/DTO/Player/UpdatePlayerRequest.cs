using System.ComponentModel.DataAnnotations;

namespace WebAPICodeFirst.DTO.Player
{
    public class UpdatePlayerRequest
    {
        [Required]
        public string NickName { get; set; }
    }
}
