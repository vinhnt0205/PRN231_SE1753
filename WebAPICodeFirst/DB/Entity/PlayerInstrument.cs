namespace WebAPICodeFirst.DB.Entity
{
    public class PlayerInstrument
    {
        public int PlayerInstrumentId { get; set; }
        public int PlayerId { get; set; }
        public Player? Player { get; set; }
        public int InstrumentTypeId { get; set; }
        public InstrumentType? InstrumentType { get; set; }
        public string ModelName { get; set; }
        public string Level { get; set; }
    }
}
