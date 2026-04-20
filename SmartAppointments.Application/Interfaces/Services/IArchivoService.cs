using SmartAppointments.Application.DTOs.Common;

namespace SmartAppointments.Application.Interfaces.Services
{
    public interface IArchivoService
    {
        Task<ApiResponse<IEnumerable<GeneralesDTO>>> Estados(int tipo);
    }
}
