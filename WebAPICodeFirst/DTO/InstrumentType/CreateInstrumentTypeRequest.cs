using System.ComponentModel.DataAnnotations;

namespace WebAPICodeFirst.DTO.InstrumentType
{
    public class CreateInstrumentTypeRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
