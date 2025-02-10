using WebAPICodeFirst.DTO.PlayerInstrument;

namespace WebAPICodeFirst.DTO.InstrumentType
{
    public class GetInstrumentTypeResponse
    {
        public int InstrumentTypeId { get; set; }
        public string Name { get; set; }
        public List<GetPlayerInstrumentResponse> PlayerInstruments { get; set; }
    }
}
