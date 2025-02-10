using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICodeFirst.DTO.InstrumentType;
using WebAPICodeFirst.Services.InstrumentTypeServices;

namespace WebAPICodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentTypeController : ControllerBase
    {
        IInstumentTypeService _instrumentTypeService;
        public InstrumentTypeController(IInstumentTypeService instrumentTypeService)
        {
            _instrumentTypeService = instrumentTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetInstrumentTypesAsync()
        {
            return Ok(await _instrumentTypeService.GetInstrumentTypesAsync());
        }
        [HttpGet("{id}/detail")]
        public async Task<IActionResult> GetInstrumentTypeAsyncById(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            return Ok(await _instrumentTypeService.GetInstrumentTypeAsyncById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateInstrumentTypeAsync([FromBody] CreateInstrumentTypeRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _instrumentTypeService.CreateInstrumentTypeAsync(request);
            return Ok(request);
        }
        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateInstrumentTypeAsync(int id, [FromBody] UpdateInstrumentTypeRequest request)
        {
            if(!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }
            var result = await _instrumentTypeService.UpdateInstrumentTypeAsync(id, request);
            return Ok(result);
        }
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteInstrumentTypeAsync(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            var result = await _instrumentTypeService.DeleteInstrumentTypeAsync(id);
            return Ok(result);
        }
    }
}
