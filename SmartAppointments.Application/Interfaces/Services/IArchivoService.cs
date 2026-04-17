using SmartAppointments.Application.DTOs.Common;

namespace SmartAppointments.Application.Interfaces.Services
{
    public interface IArchivoService
    {
        Task<IEnumerable<GeneralesDTO>> Estados(int tipo);
    }
}
