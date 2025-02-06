using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPICodeFirst.DB;
using WebAPICodeFirst.DB.Entity;
using WebAPICodeFirst.DTO;
using WebAPICodeFirst.DTO.Player;
using WebAPICodeFirst.DTO.PlayerInstrument;

namespace WebAPICodeFirst.Services.PlayerServices
{
    public class PlayerService : IPlayerService
    {
        private readonly WebAPICodeFirstContext _context;
        private readonly IMapper _mapper;

        public PlayerService(IMapper mapper, WebAPICodeFirstContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task CreatePlayerAsync(CreatePlayerRequest playerRequest)
        {
            var player = _mapper.Map<Player>(playerRequest);
            player.JoinedDate = DateTime.Now;
            var playerAdded = await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();

            var playerInstruments = _mapper.Map<List<PlayerInstrument>>(playerRequest.PlayerInstrument);
            playerInstruments.ForEach(pi => pi.PlayerId = playerAdded.Entity.PlayerId);
            await _context.PlayerInstruments.AddRangeAsync(playerInstruments);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeletePlayerAsync(int id)
        {
            try
            {
                _context.PlayerInstruments.RemoveRange(_context.PlayerInstruments.Where(p=>p.PlayerId == id).ToList());
                await _context.SaveChangesAsync();

                _context.Players.Remove(_context.Players.Find(id));
                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<PagedResponse<GetPlayerResponse>> GetPlayersAsync(UrlQueryParamters urlQueryParamters)
        {
            try
            {
                var players = _context.Players.Include(i=>i.Instruments).AsQueryable();
                if(!string.IsNullOrEmpty(urlQueryParamters.Search))
                {
                    players = players.Where(p => p.NickName.Contains(urlQueryParamters.Search));
                }
                var totalItems = await players.CountAsync();
                var page = urlQueryParamters.Page;
                var pageSize = urlQueryParamters.PageSize;
                List<GetPlayerResponse> response;
                int totalPages = 0;
                if (page == 0 && pageSize == 0)
                {
                    response = _mapper.Map<List<GetPlayerResponse>>(await players.ToListAsync());
                }
                else
                {
                    totalPages = (totalItems + pageSize) / pageSize;
                    response = _mapper.Map<List<GetPlayerResponse>>(
                        await players
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync());
                }
                var pagedResponse = new PagedResponse<GetPlayerResponse>
                {
                    Data = response,
                    Page = page,
                    PageSize = pageSize,
                    TotalItems = totalItems,
                    TotalPage = totalPages
                };
                return pagedResponse;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<GetPlayerDetailResponse> GetPlayerDetailAsync(int id)
        {
            try
            {
                var player = await _context.Players.Include(i => i.Instruments).SingleOrDefaultAsync(p => p.PlayerId == id);
                var playerMapper = _mapper.Map<GetPlayerDetailResponse>(player);
                playerMapper.PlayerInstruments = _mapper.Map<List<GetPlayerInstrumentResponse>>(player.Instruments);
                return playerMapper;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest)
        {
            try
            {
                var player = await _context.Players.FindAsync(id);
                player.NickName = playerRequest.NickName;
                _context.Players.Update(player);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
