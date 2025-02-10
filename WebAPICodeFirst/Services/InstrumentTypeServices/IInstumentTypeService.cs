using WebAPICodeFirst.DB.Entity;
using WebAPICodeFirst.DTO.InstrumentType;

namespace WebAPICodeFirst.Services.InstrumentTypeServices
{
    public interface IInstumentTypeService
    {
        Task CreateInstrumentTypeAsync(CreateInstrumentTypeRequest request);
        Task<GetInstrumentTypeResponse> GetInstrumentTypeAsyncById(int instrumentTypeId);
        Task<bool> UpdateInstrumentTypeAsync(int instrumentTypeId, UpdateInstrumentTypeRequest request);
        Task<bool> DeleteInstrumentTypeAsync(int instrumentTypeId);
        Task<List<GetInstrumentTypeResponse>> GetInstrumentTypesAsync();
    }
}
