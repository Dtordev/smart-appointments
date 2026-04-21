using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAppointments.Application.Interfaces.Services;

namespace SmartAppointments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoController : BaseController
    {
        private readonly IArchivoService _service;

        public ArchivoController(IArchivoService service)
        {
            _service = service;
        }


        #region Generales

        [AllowAnonymous]
        [HttpGet("Estados")]
        public async Task<IActionResult> Estados(int tipo)
        {
            var result = await _service.Estados(tipo);
            return FromResult(result);
        }

        [AllowAnonymous]
        [HttpGet("Obtener_Paises")]
        public async Task<IActionResult> Obtener_Paises()
        {
            var result = await _service.Obtener_Paises();
            return FromResult(result);
        }

        [AllowAnonymous]
        [HttpGet("Especialidades")]
        public async Task<IActionResult> Especialidades()
        {
            var result = await _service.Especialidades();
            return FromResult(result);
        }

        [HttpGet("ProfesionalyEntidad")]
        public async Task<IActionResult> ProfesionalyEntidad(int id_persona)
        {
            var result = await _service.ProfesionalyEntidad(id_persona);
            return FromResult(result);
        }

        [AllowAnonymous]
        [HttpGet("PosiblesHoras")]
        public async Task<IActionResult> PosiblesHoras()
        {
            var result = await _service.PosiblesHoras();
            return FromResult(result);
        }

        #endregion
    }
}
