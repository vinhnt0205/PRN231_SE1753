using System.ComponentModel.DataAnnotations;

namespace WebAPICodeFirst.DTO.InstrumentType
{
    public class UpdateInstrumentTypeRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
