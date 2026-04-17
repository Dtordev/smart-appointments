using Microsoft.AspNetCore.Mvc;
using SmartAppointments.Application.DTOs.Common;
using SmartAppointments.Application.Interfaces.Services;

namespace SmartAppointments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoController : ControllerBase
    {
        private readonly IArchivoService _service;

        public ArchivoController(IArchivoService service)
        {
            _service = service;
        }

        [HttpGet("Estados")]
        public async Task<ActionResult<IEnumerable<GeneralesDTO>>> Estados(int tipo)
        {
            var result = await _service.Estados(tipo);
            return Ok(result);
        }
    }
}
