using Microsoft.AspNetCore.Mvc;
using SmartAppointments.Application.DTOs.Common;

namespace SmartAppointments.Api.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult FromResult<T>(ApiResponse<T> result)
        {
            if (result == null)
                return StatusCode(500, new { Success = false, Message = "Internal Server Error" });

            if (!result.Success)
            {
                if (result.StatusCode == 401)
                    return Unauthorized(result);

                if (result.StatusCode == 404)
                    return NotFound(result);

                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
