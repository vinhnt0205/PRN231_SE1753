namespace WebAPICodeFirst.DB.Entity
{
    public class InstrumentType
    {
        public int InstrumentTypeId { get; set; }
        public string Name { get; set; }
        public List<PlayerInstrument> PlayerInstruments { get; set; }
    }
}
