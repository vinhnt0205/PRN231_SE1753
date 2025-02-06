using WebAPICodeFirst.DTO;
using WebAPICodeFirst.DTO.Player;

namespace WebAPICodeFirst.Services.PlayerServices
{
    public interface IPlayerService
    {

        Task CreatePlayerAsync(CreatePlayerRequest playerReuquest);
        Task<bool> DeletePlayerAsync(int id);
        Task<PagedResponse<GetPlayerResponse>> GetPlayersAsync(UrlQueryParamters urlQueryParamters);
        Task<GetPlayerDetailResponse> GetPlayerDetailAsync(int id);
        Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest);
    }
}
