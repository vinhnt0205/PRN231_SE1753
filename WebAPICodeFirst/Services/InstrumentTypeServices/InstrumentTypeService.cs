using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPICodeFirst.DB;
using WebAPICodeFirst.DB.Entity;
using WebAPICodeFirst.DTO.InstrumentType;
using WebAPICodeFirst.DTO.PlayerInstrument;

namespace WebAPICodeFirst.Services.InstrumentTypeServices
{
    public class InstrumentTypeService : IInstumentTypeService
    {
        private readonly WebAPICodeFirstContext _context;
        private readonly IMapper _mapper;

        public InstrumentTypeService(IMapper mapper, WebAPICodeFirstContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateInstrumentTypeAsync(CreateInstrumentTypeRequest request)
        {
            var instrumentType = _mapper.Map<InstrumentType>(request);
            _context.InstrumentTypes.Add(instrumentType);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteInstrumentTypeAsync(int instrumentTypeId)
        {
            var playerInstruments = await _context.PlayerInstruments.Where(pi => pi.InstrumentTypeId == instrumentTypeId).ToListAsync();
            if(playerInstruments.Count > 0)
            {
                _context.PlayerInstruments.RemoveRange(playerInstruments);
                await _context.SaveChangesAsync();
            }
            var instrumentType = await _context.InstrumentTypes.FindAsync(instrumentTypeId);
            if(instrumentType == null)
            {
                return false;
            }
            _context.InstrumentTypes.Remove(instrumentType);
            var result = await _context.SaveChangesAsync()>0;
            return result;

        }

        public async Task<GetInstrumentTypeResponse> GetInstrumentTypeAsyncById(int instrumentTypeId)
        {
            var instrumentType = await _context.InstrumentTypes.Include(i => i.PlayerInstruments).FirstOrDefaultAsync(i => i.InstrumentTypeId == instrumentTypeId);
            if(instrumentType == null)
            {
                return null;
            }
            var response = _mapper.Map<GetInstrumentTypeResponse>(instrumentType);
            response.PlayerInstruments = _mapper.Map<List<GetPlayerInstrumentResponse>>(instrumentType.PlayerInstruments);
            return response;

        }

        public async Task<List<GetInstrumentTypeResponse>> GetInstrumentTypesAsync()
        {
            var instrumentTypes = await _context.InstrumentTypes.Include(i => i.PlayerInstruments).ToListAsync();
            var response = _mapper.Map<List<GetInstrumentTypeResponse>>(instrumentTypes);
            for (int i=0; i < instrumentTypes.Count; i++)
            {
                response[i].PlayerInstruments = _mapper.Map<List<GetPlayerInstrumentResponse>>(instrumentTypes[i].PlayerInstruments);
            }
            return response;
        }

        public async Task<bool> UpdateInstrumentTypeAsync(int instrumentTypeId, UpdateInstrumentTypeRequest request)
        {
            var instrumentType = await _context.InstrumentTypes.FindAsync(instrumentTypeId);
            if(instrumentType == null)
            {
                return false;
            }
            _mapper.Map(request, instrumentType);
            _context.InstrumentTypes.Update(instrumentType);
            var result = await _context.SaveChangesAsync() > 0;
            return result;

        }
    }
}
